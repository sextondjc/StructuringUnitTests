// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace Example.Tests.RepositoryTests.Unit
{
    [TestClass]
    public class Create
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
        public void WillSaveValidRecord()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Create(model);

                // assert.
                Assert.IsNotNull(model);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullThrowsArgumentNullException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            Model model = null;

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Create(model);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NameLessThanFiveCharactersThrowsValidationException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            model.Name = "Val";

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Create(model);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NameMoreThanFiftyCharactersThrowsValidationException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            model.Name = "NameMoreThanFiftyCharactersThrowsValidationException";

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Create(model);
            }
        }

    }
}
