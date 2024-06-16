using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceRateLimiting
{
    public class ItemService
    {
        private static List<string> dictionary = new List<string>();

        private static List<int> usedRandomInts = new List<int>();

        private static HttpClient client = new HttpClient(); 

        private static int _batchSize = 25;
        public static List<Item> _items = new List<Item>();

        /// <summary>
        /// Gets items from API A http request
        /// </summary>
        /// <param name="requestCount"></param>
        /// <returns></returns>
        public static async Task<List<Item>> GetItemsFromApiA(int requestCount)
        {

            int itemsFetched = 0;
            var items = new List<Item>();

            while (itemsFetched < requestCount)
            {
                //// fetch items from API A
                //for (int i = 0; i < requestCount; i++)
                //{

                // made my own simple api of items objects
                var response = await client.GetStringAsync("http://localhost:27194/api/home/apia");
                var item = JsonConvert.DeserializeObject<Item>(response);
                items.Add(item);
                itemsFetched++;

                // respect the API A rate limit
                await Task.Delay(50); // 20 calls per second max
                //}
            }
            return items;
        }

        /// <summary>
        /// inserts data into api b's db with a post http call
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async static Task StoreItemsApiBToDb(List<Item> items)
        {
            Console.Clear();
            if (items == null || !items.Any())
            {
                Console.WriteLine("Items list is null or empty. Please initialize/store your items first.");
                Console.WriteLine("\nPress 'M' to return to the Ecommerce Rate Limiting Module menu...");
                while (Console.ReadKey().Key != ConsoleKey.M) { }
                return;
            }

            HttpClient client = new HttpClient();

            for (int i = 0; i < items.Count; i += _batchSize)
            {
                var batch = items.Skip(i).Take(_batchSize).ToList();
                var jsonContent = JsonConvert.SerializeObject(batch);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var responseB = await client.PostAsync("http://localhost:27194/api/home/apib", content);
                responseB.EnsureSuccessStatusCode();

                // Respect API B rate limit
                await Task.Delay(100); // 10 calls per second
            }

            Console.WriteLine($"Recieved {items.Count} Items from API A.\n");

            Console.WriteLine($"{items.Count} Items sent to API B successfully.");
            Console.WriteLine("\nPress 'M' to return to the Ecommerce Rate Limiting Module menu...");
            while (Console.ReadKey().Key != ConsoleKey.M) { }
        }

        /// <summary>
        /// Returns a list of items from the db/api A.
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Item>> FetchItemsApiA()
        {
            Console.Clear();
            Console.WriteLine("Please enter a count:");

            // read input from the user
            string input = Console.ReadLine();
            int count;

            // try to parse the input to an integer
            while (!int.TryParse(input, out count))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer:");
                input = Console.ReadLine();
            }
            count = int.Parse(input);

            // Call algorithm 2 monitoring logic
            Console.Clear();
            List<Item> items = await GetItemsFromApiA(count);

            //Console.WriteLine($"Recieved {items.Count} items from API A.");

            return items;

        }

        public async static Task FetchItemsApiAAndStoreInMemory()
        {
            _items = await FetchItemsApiA();

            Console.WriteLine($"Stored {_items.Count} items in memory from API A.");
            // allow user to return to the main menu after processing
            Console.WriteLine("\nPress 'M' to return to the Ecommerce Rate Limiting Module menu...");
            while (Console.ReadKey().Key != ConsoleKey.M) { }
        }

        /// <summary>
        /// first, retrieves all requested count of records from api 1, while respecting api usage limits with a task delay call
        /// then, inserts data into api b's db with a post call
        /// </summary>
        /// <returns></returns>
        public async static Task FetchItemsApiAtoApiB()
        {
            List<Item> items = await FetchItemsApiA();

            await StoreItemsApiBToDb(items);

            //Console.WriteLine($"\nStored {items.Count} items in API B's database.");
            // allow user to return to the main menu after processing
            //Console.WriteLine("\nPress 'M' to return to the Ecommerce Rate Limiting Module menu...");
            //while (Console.ReadKey().Key != ConsoleKey.M) { }
        }

        /// <summary>
        /// Simmply dislays all items in the memory currently from API A
        /// </summary>
        /// <param name="items"></param>
        public static void DisplayItemsInMemory(List<Item> items)
        {
            Console.Clear();
            if (items == null || !items.Any())
            {
                Console.WriteLine("No items found. Did you forget to initialize them into memory?\n");
                Console.WriteLine("Press 'M' to return to the Ecommerce Rate Limiting Module menu...");
                while (Console.ReadKey().Key != ConsoleKey.M) { }
                return;
            }
            foreach (Item item in items)
            {
                Console.WriteLine("Item ID: " + item.Id + " Item's Word: " + item.ItemWord + " Item Add Time: ");
            }

            Console.WriteLine($"\nDisplayed {items.Count} items.");
            Console.WriteLine("\nPress 'M' to return to the Ecommerce Rate Limiting Module menu...");
            while (Console.ReadKey().Key != ConsoleKey.M) { }
        }
    }
}
