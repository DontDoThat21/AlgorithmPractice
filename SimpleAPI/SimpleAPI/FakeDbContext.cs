using SimpleAPI.Models;
using System.Collections.Generic;

namespace SimpleAPI
{
    public class FakeDbContext //: DbContext
    {
        // DbSet<Item> items;
        public List<Item> _items = new List<Item>();

        public FakeDbContext() 
        {

        }

        public List<Item> AddItemsToFakeDb(List<Item> items)
        {
            foreach (var item in items)
            {
                //SqlConnection conn = new SqlConnection();
                //conn.Open();
                //string sql = "select * from my fancy sql";
                //conn.Execute(sql);

                _items.Add(item);
            }
            return _items;
        }
    }
}
