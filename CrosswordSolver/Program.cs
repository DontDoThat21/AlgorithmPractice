using AlgorithmAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using EcommerceRateLimiting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace CrosswordSolver
{
    //***********************************Instructions********************************
    /*
    *Implement a Crossword Solver
    * 1. User needs to be able to input a pattern of a combination of known letters and wildcards. 
    *  The input format should use an asterisk: '*' (U+002A) as a wildcard.
    *  Make this simple!
    *  
    * 2. The program should return all words in the dictionary that match the input pattern. 
    *  This means you won't be solving a whole crossword - just providing options for what would 
    *  fit in a crossword row or column.
    *      
    *  Example Input: b**r
    *  Output: Results: Bear, Beer, Bier, Birr, Blur, Boar, Boor, Brrr, Buhr, Burr. Found 5 words in 1000 ticks
    *   
    *  Example Input: *eel
    *  Output: Results: Feel, Heel, Keel, Peel, Reel, Seel, Teel, Weel. Found 8 words in 1000 ticks
    *   
    * 3. An example dictionary .csv is included for your convenience. You can/should use the default .NET libraries to load it.
    * 4. Using the stopwatch, be sure to indicate how long your solution takes to load its structures, and produce a result. 
    *      Hint: display the time to process a result AFTER printing them out, otherwise you won't be able to see it in large result sets.
    * 
    * A few final points:
    * 1. The order of priorities for the solution should be: Correctness, Performance, elegance, and usability.
    * 2. Startup time and memory usage are much less important than the time taken to solve the crossword pattern (which is critical).
    * 3. Error handling and input validation are nice to haves, as long as your control schemes and instructions are clear.
    * 
    */
    public class Program
    {
        private static List<string> dictionary = new List<string>();
        private static Func<string, List<string>> GetPossibleWordsFunction;   

        static void Main(string[] args)
        {
            bool exit = false;
            bool isInvalidLastChoice = false;

            do
            {
                if (isInvalidLastChoice)
                {
                    Console.WriteLine("Invalid choice. Please select either '1', '2', or '3'.\n");
                }

                isInvalidLastChoice = false;

                Console.WriteLine("Welcome to the Crossword Solver, Ecommerce Rate Limiting Module, and Algorithm Performance Monitor!\n");

                Console.WriteLine("Select an option:\n");
                Console.WriteLine("(1) Crossword Solver");
                Console.WriteLine("(2) Algorithm Performance Monitor");
                Console.WriteLine("(3) Enter Ecommerce Rate Limiting Module");
                Console.WriteLine("(4) Exit");

                string modeChoice = Console.ReadLine();

                switch (modeChoice)
                {
                    case "1":
                        Console.Clear();
                        CrosswordSolverMenu();
                        break;
                    case "2":
                        Console.Clear();
                        AlgorithmPerformanceMonitorMenu();
                        break;
                    case "3":
                        Console.Clear();
                        EcommerceRateLimitingMenu().Wait();
                        break;
                    case "4":
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        isInvalidLastChoice = true;
                        break;
                }

                Console.Clear(); // Clear the console for the next menu display

            } while (!exit);
            
        }

        /// <summary>
        /// opens ecommerce menu options
        /// </summary>
        /// <returns></returns>
        static async Task EcommerceRateLimitingMenu()
        {
            bool exit = false;
            bool isInvalidLastChoice = false;

            do
            {
                if (isInvalidLastChoice)
                {
                    Console.WriteLine("Invalid choice. Please select either '1', '2', '3', or 'M'.\n");
                }

                isInvalidLastChoice = false;

                Console.WriteLine("You've entered the Ecommerce Rate Limiting Module.\n");
                Console.WriteLine("Select a test to execute:\n");
                Console.WriteLine("(1) Fetch Items from API A then send to API B...");
                Console.WriteLine("(2) Fetch Items from API A and store in memory for later processing...");
                Console.WriteLine("(3) Store Items in API B from stored memory of existing batches...");
                Console.WriteLine("(4) Display Items stored in memory...");
                Console.WriteLine("\nPress 'M' to return to the main menu...");

                string algorithmChoice = Console.ReadLine();

                switch (algorithmChoice)
                {
                    case "1":
                        //ItemService.FetchItemsApiAtoApiB().Wait();
                        await ItemService.FetchItemsApiAtoApiB();              
                        break;
                    case "2":
                        await ItemService.FetchItemsApiAAndStoreInMemory();
                        break;
                    case "3":
                        await ItemService.StoreItemsApiBToDb(ItemService._items);
                        break; 
                    case "4":
                        ItemService.DisplayItemsInMemory(ItemService._items);
                        break;
                    case "M":
                    case "m":
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        isInvalidLastChoice = true;
                        Console.WriteLine("Invalid choice. Please select either '1', '2', '3', '4', '5', or 'M'.");
                        break;
                }

                Console.Clear();
            } while (!exit);
        }        

        /// <summary>
        /// change from main to algo menu
        /// </summary>
        static void AlgorithmPerformanceMonitorMenu()
        {
            bool exit = false;
            bool isInvalidLastChoice = false;

            do
            {
                if (isInvalidLastChoice)
                {
                    Console.WriteLine("Invalid choice. Please select either '1', '2', '3', '4', '5', or 'M'.\n");
                }

                isInvalidLastChoice = false;

                Console.WriteLine("You've chosen to monitor algorithm performance metrics.\n");
                Console.WriteLine("Select an algorithm to monitor:\n");
                Console.WriteLine("(1) Algorithm 1: Growth Table Validator");
                Console.WriteLine("(2) Algorithm 2: Batch retrievals");
                Console.WriteLine("(3) Algorithm 3: Sort and Count");
                Console.WriteLine("(4) Algorithm 4: Conditional File Saving");
                Console.WriteLine("(5) Algorithm 5: Record Retrieval");
                Console.WriteLine("\nPress 'M' to return to the main menu...");

                string algorithmChoice = Console.ReadLine();

                switch (algorithmChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Monitoring algorithm 1...\n");
                        // Call algorithm 2 monitoring logic
                        Algorithm1MetricsMonitoring();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Monitoring algorithm 2...");
                        // Call algorithm 2 perf monitoring logic
                        Algorithm2MetricsMonitoring();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Monitoring algorithm 3...");
                        // Call algorithm 3 perf monitoring logic
                        Algorithm3MetricsMonitoring();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Monitoring algorithm 4...");
                        // Call algorithm 4 perf monitoring logic
                        Algorithm4MetricsMonitoring();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Monitoring algorithm 5...");
                        // Call algorithm 5 perf monitoring logic
                        Algorithm5MetricsMonitoring();
                        break;
                    case "M":
                    case "m":
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        isInvalidLastChoice = true;
                        Console.WriteLine("Invalid choice. Please select either '1', '2', '3', '4', '5', or 'M'.");
                        break;
                }
                //Console.ReadLine();

                Console.Clear(); // Clear the console for the next menu display
            } while (!exit);
        }

        /// <summary>
        /// change from main to crossword menu
        /// </summary>
        private static void CrosswordSolverMenu()
        {
            bool exit = false;
            // Load the dictionary and setup
            Setup();

            // Prompt user for which implementation to use
            while (true)
            {
                Console.WriteLine("\nYou've chosen to retrieve matches to help solve Crossword Puzzles.");
                Console.WriteLine("Please select an output style:\n");

                Console.WriteLine("Choose implementation (*eel/*EEL example input):\n(1) Original (Output: FEEL, HEEL, KEEL, PEEL, REEL, SEEL, TEEL, WEEL)" +
                    "\n(2) Title Case (Output: Feel, Heel, Keel, Peel, Reel, Seel, Teel, Weel)" +
                    "\nNote: Title Case is ever so slightly less performant (~1-2%)");
                Console.WriteLine("\nPress 'M' to return to the main menu...");

                string patternImplementationChoice = Console.ReadLine();
                if (patternImplementationChoice == "1")
                {
                    GetPossibleWordsFunction = GetPossibleWords;
                    break;
                }
                else if (patternImplementationChoice == "2")
                {
                    GetPossibleWordsFunction = GetPossibleWordsTitleCase;
                    break;
                }
                else if (patternImplementationChoice.Equals("M", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or M.");
                }
            }

            if (exit)
            {
                return;
            }

            while (true)
            {
                // Prompt user for input pattern
                Console.WriteLine("Enter a pattern (use '*' as wildcard) or type 'M' to quit:");
                string pattern = Console.ReadLine();

                if (pattern.Equals("M", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Convert pattern to uppercase
                pattern = pattern.ToUpper();

                // Start measuring time
                var sw = Stopwatch.StartNew();

                // Get possible words using the chosen function
                var possibleWords = GetPossibleWordsFunction(pattern);

                // Stop measuring time
                sw.Stop();

                // Output results
                Console.WriteLine("Results: " + string.Join(", ", possibleWords));
                Console.WriteLine($"Found {possibleWords.Count} words in {sw.ElapsedTicks} ticks");
            }
        }

        // Perform any loading or setup here. Do your best to not change this method signature.
        /// <summary>
        /// get csv, start stopwatch, and read dictionary into memory/initialize crossword puzzle solver logic dependencies
        /// </summary>
        public static void Setup()
        {
            var sw = Stopwatch.StartNew();
            string dictionaryPath = "english.csv"; // Path to the dictionary file

            if (File.Exists(dictionaryPath))
            {
                dictionary = File.ReadAllLines(dictionaryPath).ToList();
            }
            else
            {
                Console.WriteLine("Dictionary file not found.");
            }

            sw.Stop();
            Console.WriteLine($"Dictionary loaded in {sw.ElapsedMilliseconds} ms");
        }

        //Return results from here. Do your best to not change this method signature.
        /// <summary>
        /// simple linq to match words
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static List<string> GetPossibleWords(string template)
        {
            return dictionary.Where(word => MatchesPattern(word, template)).ToList();
        }

        /// <summary>
        /// i decided to make a second method, just in case the requested output was as such (title casing)
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static List<string> GetPossibleWordsTitleCase(string template)
        {
            return dictionary
                .Where(word => MatchesPattern(word, template))
                .Select(word => ToTitleCase(word))
                .ToList();
        }

        private static string ToTitleCase(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower());
        }

        // Helper method to check if a word matches the pattern
        private static bool MatchesPattern(string word, string pattern)
        {
            if (word.Length != pattern.Length)
            {
                return false;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != '*' && pattern[i] != word[i])
                {
                    return false;
                }
            }

            return true;
        }

        // END OF CROSSWORD SOLVER HELPER METHODS.
        // BEGINNING OF ALGORITHM MONITORING HELPER METHODS TO GIVE OUTPUT TO SCREEN.

        static void Algorithm1MetricsMonitoring()
        {
            // Sample growth table data
            var growthTable = new GrowthTable(new List<GrowthTableRow>
            {
                new GrowthTableRow(1, 4, 0.1m),
                new GrowthTableRow(5, 7, 0.17m),
                new GrowthTableRow(8, 10, 0.05m),
                new GrowthTableRow(11, 53, 0.68m)
            });

            Console.WriteLine("Algorithm 1: Growth Table Validity Check");

            string growthTableRowExampleDatas = "\nExample Growth Table values being used:\n";
            for (int i = 0; i < growthTable.Rows.Count; i++)
            {
                growthTableRowExampleDatas += $"Row {i+1}: " +
                    $"Start Wk: {growthTable.Rows[i].StartWeek} " +
                    $"End Wk: {growthTable.Rows[i].EndWeek} " +
                    $"Growth: {growthTable.Rows[i].GrowthPct}\n";
            }

            Console.WriteLine(growthTableRowExampleDatas);

            // Call the IsValid method to check the validity of the growth table
            bool isValid = Algorithms1.IsValid(growthTable);

            // Output the result            
            Console.WriteLine($"Result: {(isValid ? "Valid" : "Invalid")}");
            Console.WriteLine("\nPress 'M' to return to the main menu...");
            Console.ReadLine();
        }

        static void Algorithm2MetricsMonitoring()
        {
            // Sample data for monitoring Algorithm 2
            Random random = new Random();
            var sampleData = Enumerable.Range(1, random.Next(1, 15001));

            // Define the maximum batch size
            int maxBatchSize = 10;

            // Call the Batch method of Algorithm 2 with the sample data
            var batches = Algorithms2.Batch(sampleData, maxBatchSize);

            // Output the results
            Console.WriteLine("\nAlgorithm 2: Batch Processing\n");
            int batchCount = 0;
            foreach (var batch in batches)
            {
                Console.WriteLine($"Batch {++batchCount}: Count = {batch.Count}");
            }
            Console.WriteLine("\nPress 'M' to return to the main menu...");
            Console.ReadLine();
        }

        static void Algorithm3MetricsMonitoring()
        {
            // Call SortByLastNameThenFirstName method of Algorithm 3
            var sortedList = Algorithms3.SortByLastNameThenFirstName();

            // Output the sorted list
            Console.WriteLine("\nAlgorithm 3: Sort By Last Name Then First Name\n");
            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }

            // Call CountsByFirstName method of Algorithm 3
            var countsList = Algorithms3.CountsByFirstName();

            // Output the counts list
            Console.WriteLine("\nAlgorithm 3: Counts By First Name\n");
            foreach (var item in countsList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress 'M' to return to the main menu...");
            Console.ReadLine();
        }

        static void Algorithm4MetricsMonitoring()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] filesStartingWithA = Directory.GetFiles(desktopPath, "a*", SearchOption.TopDirectoryOnly);

            try
            {
                Console.WriteLine("\nAlgorithm 4: Save Lines Starting with 'a'\n");
                for (int i = 0; i < filesStartingWithA.Length; i++)
                {
                    string inputFilePath = filesStartingWithA[i];
                    string outputFileName = $"Algorithm4_{i + 1}.txt";
                    string outputFilePath = Path.Combine(desktopPath, outputFileName);

                    // Check if the output file already exists
                    int count = 1;
                    while (File.Exists(outputFilePath))
                    {
                        // If the file exists, append a numeric suffix to make it unique
                        outputFileName = $"Algorithm4_{i + 1}_{count}.txt";
                        outputFilePath = Path.Combine(desktopPath, outputFileName);
                        count++;
                    }

                    // Read the contents of the input file
                    string fileContent = File.ReadAllText(inputFilePath);

                    // Write the contents to the output file
                    File.WriteAllText(outputFilePath, fileContent);

                    Console.WriteLine($"Output file '{outputFilePath}' created successfully.");
                }

                if (filesStartingWithA.Length > 0)
                {
                    Console.WriteLine("All files created successfully.");
                }
                else
                {
                    Console.WriteLine("No files found starting with 'a' or 'A'.");
                }
                

                Console.WriteLine("\nPress 'M' to return to the main menu...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError occurred while executing Algorithm 4: {ex.Message}");
            }

            Console.ReadLine();
        }

        static void Algorithm5MetricsMonitoring()
        {
            // Sample data for monitoring Algorithm 5
            var sampleRecords = new List<Algorithms5.Record>
            {
                new Algorithms5.Record { PK_1 = 1, PK_2 = 101, Value = "Example value one" },
                new Algorithms5.Record { PK_1 = 2, PK_2 = 102, Value = "Example value two" },
                new Algorithms5.Record { PK_1 = 3, PK_2 = 103, Value = "Example value three" },
                new Algorithms5.Record { PK_1 = 4, PK_2 = 104, Value = "Example value four" },
                new Algorithms5.Record { PK_1 = 5, PK_2 = 105, Value = "Example value five" }
            };

            try
            {
                // Create an instance of Algorithm 5 and load records into the cache
                var algorithm5 = new Algorithms5();
                algorithm5.LoadRecordsIntoCache(sampleRecords);

                // Retrieve some records from the cache
                var retrievedRecord1 = algorithm5.GetRecord(1, 101);
                var retrievedRecord2 = algorithm5.GetRecord(2, 102);
                var retrievedRecord3 = algorithm5.GetRecord(3, 103);
                var retrievedRecord4 = algorithm5.GetRecord(4, 104);
                var retrievedRecord5 = algorithm5.GetRecord(5, 105);

                // Output the results
                Console.WriteLine("\nAlgorithm 5: Cache Records\n");
                Console.WriteLine($"Retrieved Record 1: {(retrievedRecord1 != null ? retrievedRecord1.Value : "Not found")}");
                Console.WriteLine($"Retrieved Record 2: {(retrievedRecord2 != null ? retrievedRecord2.Value : "Not found")}");
                Console.WriteLine($"Retrieved Record 3: {(retrievedRecord3 != null ? retrievedRecord3.Value : "Not found")}");
                Console.WriteLine($"Retrieved Record 4: {(retrievedRecord4 != null ? retrievedRecord4.Value : "Not found")}");
                Console.WriteLine($"Retrieved Record 5: {(retrievedRecord5 != null ? retrievedRecord5.Value : "Not found")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while executing Algorithm 5: {ex.Message}");
            }
            Console.WriteLine("\nPress 'M' to return to the main menu...");
            Console.ReadLine();
        }
    }
}
