using System;
using System.Collections.Generic;
using System.Diagnostics;
using Simple.DotNMap.Extensions;

namespace Simple.DotNMap.Demo{
    public class Runner{
        /// <summary>
        ///   Gets or sets the output path and filename.
        /// </summary>
        /// <value> The file path. </value>
        /// <remarks>
        ///   OPTIONAL. If not specified a default path and filename is "nmaprun_[GUID].xml".
        /// </remarks>
        /// <example>
        ///   c:\scan.xml
        /// </example>
        public string FilePath { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Runner" /> class.
        /// </summary>
        public Runner(){
            FilePath = string.Format(@"nmaprun_{0}.xml", Guid.NewGuid());
        }

        /// <summary>
        ///   Scans the specified targets.
        /// </summary>
        /// <param name="targets"> The targets, IP or Hostname </param>
        /// <returns> A resulting nmaprun instance. </returns>
        public nmaprun Scan(IEnumerable<string> targets){
            scan(targets);
            nmaprun nmapScan = Serialization.DeserializeFromFile<nmaprun>(FilePath);
            return nmapScan;
        }

        private void scan(IEnumerable<string> targets){
            using (Process process = new Process()){
                string arguments = string.Format("-P0 -sSU -top-ports 10 --traceroute -oX {0} {1}", FilePath, string.Join(" ", targets));
                ProcessStartInfo startInfo = new ProcessStartInfo("nmap.exe", arguments)
                { WindowStyle = ProcessWindowStyle.Hidden };

                process.StartInfo = startInfo;
                process.Start();

                while (!process.HasExited){
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
}