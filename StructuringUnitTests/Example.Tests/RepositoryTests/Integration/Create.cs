// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Example.Tests.RepositoryTests.Integration
{
    [TestClass]
    public class Create
    {        
        [TestMethod]
        public void WillSaveValidRecord()
        {
            // omitted - it's just a demo & there's nothing to integrate against :). 
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullThrowsArgumentNullException()
        {            
            throw new ArgumentNullException("Just a demo.");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NameLessThanFiveCharactersThrowsValidationException()
        {
            throw new ValidationException("Just a demo.");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void NameMoreThanFiftyCharactersThrowsValidationException()
        {
            throw new ValidationException("Just a demo.");
        }

    }
}
