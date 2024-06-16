using SimpleAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SimpleAPI
{
    public class HelperClass
    {
        public static List<Item> dictionary = new List<Item>();

        public static List<Item> SetupItemsToMemory()
        {
            if ((dictionary != null) && (!dictionary.Any()))
            {
                string dictionaryPath = "english.csv"; // Path to the dictionary file
                List<string> words = new List<string>();

                if (System.IO.File.Exists(dictionaryPath))
                {
                    words = System.IO.File.ReadAllLines(dictionaryPath).ToList();
                    for (int i = 0; i < words.Count; i++)
                    {
                        dictionary.Add(
                             new Item
                             {
                                 Id = i,
                                 ItemWord = words[i],
                                 ItemDate = DateTime.Now
                             }
                        );
                    }
                    var rnd = new Random();
                    dictionary = dictionary.OrderBy(item => rnd.Next(0, dictionary.Count)).ToList();
                }
                else
                {
                    Console.WriteLine("Dictionary file not found.");
                    throw new Exception();
                }
                return dictionary;
            }
            else
            {
                return new List<Item>();
            }

        }

    }
}
