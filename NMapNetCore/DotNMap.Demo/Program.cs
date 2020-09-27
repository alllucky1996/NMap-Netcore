using DotNMap;
using System;
using System.IO;

namespace DotNMap.Demo{
    internal class Program{
        private static void Main(string[] args){
            
            Console.WriteLine("Scanning Targets...");
            if (args.Length == 0){
                Console.WriteLine("No Targets provided");
                Console.WriteLine("Done. Press any key to continue.");
                Console.ReadKey();
            }
            string[] targets = args[0].Split(',');
            string outputDirectoryPath = args.Length == 2 ? args[1] : Directory.GetCurrentDirectory();
            OutputFileProvider outputFileProvider=new OutputFileProvider(outputDirectoryPath,"scan_*.xml");
            
            Runner runner = new Runner{FilePath = Path.Combine(outputDirectoryPath, outputFileProvider.Next())};

            nmaprun lastRun = runner.Scan(targets);
            Console.WriteLine("Scan complete, Output written to "+runner.FilePath);
            ObjectDumper.Write(lastRun,5);
            Console.WriteLine("Done. Press any key to continue.");
            Console.ReadKey();

        }

        
    }
}