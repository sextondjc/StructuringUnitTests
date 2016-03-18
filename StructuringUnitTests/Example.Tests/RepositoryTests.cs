// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Example.Tests.CurrentConvention
{
    [TestClass]
    public class RepositoryTests
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
        public void Create_ValidModel_WillSaveRecord()
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
        public void Create_NullModel_ThrowsArgumentNullException()
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
        public void Create_NameLessThanFiveCharacters_ThrowsValidationException()
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
        public void Create_NameMoreThanFiftyCharacters_ThrowsValidationException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            model.Name = "Create_NameMoreThanFiftyCharacters_ThrowsValidationException";

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Create(model);
            }
        }

        [TestMethod]
        public void Update_ValidModel_WillSaveRecord()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Update(model);

                // assert.
                Assert.IsNotNull(model);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_NullModel_ThrowsArgumentNullException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            Model model = null;

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Update(model);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Update_NameLessThanFiveCharacters_ThrowsValidationException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            model.Name = "Val";

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Update(model);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Update_NameMoreThanFiftyCharacters_ThrowsValidationException()
        {
            // arrange
            _commanderMock.Setup(x => x.Command(It.IsAny<Model>())).Returns(true);
            var model = createModel();

            model.Name = "Create_NameMoreThanFiftyCharacters_ThrowsValidationException";

            // act
            using (var repository = new Repository<Model>(_commanderMock.Object))
            {
                var result = repository.Update(model);
            }
        }

        [TestMethod]
        public void Delete_ExistingRecord_IsDeleted()
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
        public void Delete_NullRecord_ReturnsNull()
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

        [TestMethod]
        public void Retrieve_ExisingRecord_IsRetrieved()
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
        public void Retrieve_EmptyGuid_ThrowsArgumentException()
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

        [TestMethod]
        public void RetrieveAll_ReturnsCollection()
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
