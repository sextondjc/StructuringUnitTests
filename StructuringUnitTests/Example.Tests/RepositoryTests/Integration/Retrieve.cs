﻿// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Tests.RepositoryTests.Integration
{
    [TestClass]
    public class Retrieve
    {
        [TestMethod]
        public void ExisingRecord()
        {
            // omitted - it's just a demo & there's nothing to integrate against :). 
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyGuidThrowsArgumentException()
        {
            throw new ArgumentException("Just a demo.");
        }
    }
}
