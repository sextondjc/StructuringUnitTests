// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Example.Tests.RepositoryTests.Unit
{
    [TestClass]
    public class Retrieve
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
        public void ExisingRecord()
        {
            // arrange
            _commanderMock.Setup(x => x.Query<Model>(It.IsAny<Guid>())).Returns(createModel());

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var id = Guid.NewGuid();
                var result = repository.Retrieve<Model>(id);
                // assert
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyGuidThrowsArgumentException()
        {
            // arrange
            _commanderMock.Setup(x => x.Query<Model>(It.IsAny<Guid>())).Returns(createModel());

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var id = Guid.Empty;
                var result = repository.Retrieve<Model>(id);
            }
        }
    }
}
