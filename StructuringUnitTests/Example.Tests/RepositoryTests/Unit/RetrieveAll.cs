// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Example.Tests.RepositoryTests.Unit
{
    [TestClass]
    public class RetrieveAll
    {
        #region / init /

        private Mock<IDbCommander> _commanderMock;

        [TestInitialize]
        public void Initialize()
        {
            _commanderMock = new Mock<IDbCommander>();
        }

        private Model createModel() => new Model
        {
            Id = Guid.NewGuid(),
            Name = "Valid Model",
            Quantity = 1
        };

        #endregion

        [TestMethod]
        public void ReturnsCollection()
        {
            // arrange
            var collection = new List<Model>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add(createModel());
            }
            _commanderMock.Setup(x => x.Query<Model>()).Returns(collection);

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.RetrieveAll();

                // assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(IEnumerable<Model>));
                Assert.IsTrue(result.Any());
                Assert.AreEqual(10, result.Count());
            }
        }
    }
}
