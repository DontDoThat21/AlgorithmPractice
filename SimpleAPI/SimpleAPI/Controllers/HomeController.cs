using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleAPI.Controllers
{
    /// <summary>
    /// Make sure you run this SimpleAPI site in another instance of VS.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]    
    public class HomeController : ControllerBase
    {
        private static List<Item> dictionary = new List<Item>();

        private static readonly object setupLock = new object();
        private static bool isInitialized = false;
        private static int itemsInMemoryCount = 10000;
        private static FakeDbContext _fakeDbContext;

        public HomeController(FakeDbContext fakeDbContext)
        {
            _fakeDbContext = fakeDbContext;

            // Ensure the dictionary is initialized only once
            if (!isInitialized)
            {
                lock (setupLock)
                {
                    if (!isInitialized)
                    {
                        dictionary = HelperClass.SetupItemsToMemory();
                        isInitialized = true;
                    }
                }
            }
        }        

        /// <summary>
        /// /// <summary>
        /// Make sure you run this SimpleAPI site in another instance of VS.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        /// </summary>
        /// <returns></returns>
        [HttpGet("ApiA")]
        public Item ApiA()
        {
            var rng = new Random();
            int next = rng.Next(0, itemsInMemoryCount);
            return dictionary[next];
        }

        /// <summary>
        /// Make sure you run this SimpleAPI site in another instance of VS.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [HttpPost("ApiB")]
        public IActionResult ApiB([FromBody] List<Item> items)
        {
            if (items == null || !items.Any())
            {
                return BadRequest("Items list is null or empty.");
            }

            _fakeDbContext.AddItemsToFakeDb(items);

            return Ok();
        }   

    }
}
