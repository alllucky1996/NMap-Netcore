using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNMap;
using DotNMap.Extensions;

namespace DotNMap.Test{
    [TestClass]
    [DeploymentItem("scan_1.xml")]
    public class SerializationTest{
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void DeserializeFromFileTest(){
            nmaprun actual = Serialization.DeserializeFromFile<nmaprun>("scan_1.xml");
            Assert.IsInstanceOfType(actual, typeof (nmaprun));
        }

        [TestMethod]
        public void DeserializeTest(){
            string xml = File.ReadAllText("scan_1.xml");
            nmaprun scan = Serialization.Deserialize<nmaprun>(xml);
            Assert.IsInstanceOfType(scan, typeof (nmaprun));
        }

        [TestMethod]
        public void SerializeToFileTest(){
            nmaprun scan = Serialization.DeserializeFromFile<nmaprun>("scan_1.xml");
            scan.SerializeToFile("scan_2.xml");
            Assert.IsTrue(File.Exists("scan_2.xml"));
        }

        [TestMethod]
        public void SerializeTest(){
            nmaprun scan = Serialization.DeserializeFromFile<nmaprun>("scan_1.xml");
            string xml = scan.Serialize();
            Assert.IsNotNull(xml);
        }
    }
}