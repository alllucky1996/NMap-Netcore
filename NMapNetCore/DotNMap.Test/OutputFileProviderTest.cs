using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNMap;
using DotNMap.Demo;

namespace DotNMap.Test{
    [TestClass]
    public class OutputFileProviderTest{
        public TestContext TestContext { get; set; }
        [ClassInitialize]
        public static void ClassSetup(TestContext context){
            DirectoryInfo directoryInfo = Directory.CreateDirectory(Path.Combine(context.TestDeploymentDir, "Scans"));
            createScanFile(directoryInfo, "scan_1.xml");
            createScanFile(directoryInfo, "scan_2.xml");
            createScanFile(directoryInfo, "scan_4.xml");
            createScanFile(directoryInfo, "scan_11.xml");
            createScanFile(directoryInfo, "scan_23.xml");
        }

        private static void createScanFile(DirectoryInfo directoryInfo, string scanFileName){
            File.Create(Path.Combine(directoryInfo.ToString(), scanFileName));
        }

        [TestMethod]
        public void NextTest(){
            string outputDirectory = Path.Combine(TestContext.TestDeploymentDir, "Scans");
            string pattern = "scan_*.xml";
            OutputFileProvider outputFileProvider = new OutputFileProvider(outputDirectory, pattern);
            string expected = Path.Combine(outputDirectory,"SCAN_3.XML");
            string actual = outputFileProvider.Next();
            Assert.AreEqual(expected.ToUpper(), actual.ToUpper());
          
        }

        [TestMethod]
        public void Next_Out_Test()
        {
            string outputDirectory = Path.Combine(TestContext.TestDeploymentDir, "Scans");
            string pattern = "out*.xml";
            OutputFileProvider outputFileProvider = new OutputFileProvider(outputDirectory, pattern);
            string expected = Path.Combine(outputDirectory, "out1.XML");
            string actual = outputFileProvider.Next();
            Assert.AreEqual(expected.ToUpper(), actual.ToUpper());

        }
    }
}