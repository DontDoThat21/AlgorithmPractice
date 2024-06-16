using System;
using System.Collections.Generic;

namespace AlgorithmAnalysis
{
    public static class Algorithms2
    {
        // Implement this function. Return a stream of batches of size <= maxBatchSize while enumerating over the input enumerable.
        // Each batch is defined as a List<T> where List<T>.Count <= maxBatchSize
        /// <summary>
        /// batches elements of a sequence into sized groups. 
        /// </summary>
        /// <typeparam name="T">types of elememnts in the sequence</typeparam>
        /// <param name="enumerable">sequence of elements to batch request</param>
        /// <param name="maxBatchSize">max number of elements in each batch</param>
        /// <returns>enumerable of lists where each list contains a batch of T generic elements</returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> enumerable, int maxBatchSize)
        {
            if (maxBatchSize <= 0)
            {
                throw new ArgumentException("maxBatchSize must be greater than zero.");
            }

            List<T> currentBatch = new List<T>();

            foreach (var item in enumerable)
            {
                currentBatch.Add(item);

                if (currentBatch.Count >= maxBatchSize)
                {
                    yield return currentBatch;
                    currentBatch = new List<T>();
                }
            }

            // Yield the remaining elements as the last batch if its not empty
            if (currentBatch.Count > 0)
            {
                yield return currentBatch;
            }
        }
    }
}
