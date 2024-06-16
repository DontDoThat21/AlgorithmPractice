using System.IO;
using System.Text;

namespace AlgorithmAnalysis
{
    /// <summary>
    /// provides functionality to save lines from a file that start with the first letter of the alphabet to a new file.
    /// hard coded only because it was requested to be in implementation instructions
    /// </summary>
    public class Algorithms4
    {
        // Save all file lines that start with the first letter of the alphabet to a new file
        // Must be able to handle VERY large files.
        /// <summary>
        /// saves file lines of presumably text file to output path (desktop by default)
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        /// <exception cref="FileNotFoundException"></exception>
        public void SaveLines(string inputFilePath, string outputFilePath)
        {
            // Didn't want to alter the signature to follow suit of all other examples, so as requested 'a' will
            // be the hard coded decider of whether to save a file. If we wanted to change this method to be dynamic,
            // it would simply be a method paramater added to the signature above.

            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException($"Input file '{inputFilePath}' not found.");
            }

            using (var reader = new StreamReader(inputFilePath)) // get file
            using (var writer = new StreamWriter(outputFilePath, false, Encoding.UTF8)) // write file
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                { // confirm start with a hard coded as requested
                    if (!string.IsNullOrWhiteSpace(line) && char.ToLower(line[0]) == 'a')
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
