using System;
using System.IO;

namespace DotNMap.Demo{
    /// <summary>
    /// The output file provider.
    /// </summary>
    public class OutputFileProvider{
        private readonly string _outputDirectory;
        private readonly string _pattern;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFileProvider"/> class.
        /// </summary>
        /// <param name="outputDirectory">The output directory.</param>
        /// <param name="pattern">The pattern.</param>
        public OutputFileProvider(string outputDirectory, string pattern){
            if (outputDirectory == null){
                throw new ArgumentNullException("outputDirectory");
            }
            if (pattern == null){
                throw new ArgumentNullException("pattern");
            }
            _outputDirectory = outputDirectory;
            _pattern = pattern;
        }

        /// <summary>
        ///   Gets the next sequential file name, for the given pattern, that does not already exist in the provided output folder.
        /// </summary>
        /// <returns>The next available file name. </returns>
        public string Next(){
            string parsedPattern = _pattern.Replace("*", "{0}");
            for (int i = 1; i < 100; i++){
                string currentFile = Path.Combine(_outputDirectory, string.Format(parsedPattern, i));
                if (!File.Exists(currentFile)){
                    return currentFile;
                }
            }
            return null;
        }
    }
}