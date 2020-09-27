using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNMap;
using DotNMap.Demo;

namespace DotNMap.Test{
    [TestClass]
    public class RunnerTest{
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void ScanTest(){
            Runner runner = new Runner();
            nmaprun nmaprun = runner.Scan(new[]{"scanme.nmap.org"});
            Assert.IsInstanceOfType(nmaprun,typeof(nmaprun));
        }
    }
}