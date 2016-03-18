// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Example.Tests.RepositoryTests.Unit
{
    [TestClass]
    public class Delete
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
        public void WillDeleteExistingRecord()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Delete(model);

                // assert
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void NullReturnsNull()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            Model model = null;

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Delete(model);

                // assert
                Assert.IsNull(result);
            }
        }
    }
}
