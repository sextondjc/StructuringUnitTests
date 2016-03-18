// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Tests.RepositoryTests.Performance
{
    [TestClass]
    public class Delete
    {
        [TestMethod]
        public void ReturnsSingleDeleteInUnderOneSecond()
        {
            // ommitted - just a demo. 
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeletesOneThousandRecordsInUnderFiveSeconds()
        {
            // ommitted - just a demo. 
            Assert.IsTrue(true);
        }        
    }
}
