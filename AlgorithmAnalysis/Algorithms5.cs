using System.Collections.Generic;

namespace AlgorithmAnalysis
{
    // The order of priorities for the solution should be: Correctness, Performance, and Style.
    // Do not alter method signatures
    /// <summary>
    /// represents a cache structure for efficiently storing and retrieving records
    /// </summary>
    public class Algorithms5
    {
        // Create an efficient cache of records as a field.
        // The structure of a cache should not be a .NET MemoryCache. Use your own data structure.
        private Dictionary<(int, int), LinkedListNode<Record>> _cache; // linked list due to first node efficiency
        private LinkedList<Record> _accessOrder; // Maintains the most recently accessed records at the front

        // Record should be indexed by the combination of pk_1 and pk_2 (each are part of the "primary key").        
        public class Record
        {
            public int PK_1 { get; set; }
            public int PK_2 { get; set; }
            public string Value { get; set; }
        }

        // Implement
        /// <summary>
        /// Loads the provided records into the cache for fast retrieval
        /// </summary>
        /// <param name="records">Records to be loaded into cache</param>
        public void LoadRecordsIntoCache(IEnumerable<Record> records)
        {
            _cache = new Dictionary<(int, int), LinkedListNode<Record>>();
            _accessOrder = new LinkedList<Record>();

            foreach (var record in records)
            {
                AddToCache(record);
            }
        }

        // Implement. Retrieve value from the cache. Retrieval should be very fast.
        /// <summary>
        /// retrieves a record from the cache using the specified primary key values
        /// </summary>
        /// <param name="pk_1">first part of composite primary key</param>
        /// <param name="pk_2">second part of composite primary key</param>
        /// <returns>record associated, otherwise null</returns>
        public Record GetRecord(int pk_1, int pk_2)
        {
            if (_cache.TryGetValue((pk_1, pk_2), out var node))
            {
                // Move the accessed record to the front of the access order list
                _accessOrder.Remove(node);
                _accessOrder.AddFirst(node);
                return node.Value;
            }

            return null;
        }

        // helper method to add a record to the cache
        private void AddToCache(Record record)
        {
            var node = _accessOrder.AddFirst(record);
            _cache[(record.PK_1, record.PK_2)] = node;
        }
    }
}
