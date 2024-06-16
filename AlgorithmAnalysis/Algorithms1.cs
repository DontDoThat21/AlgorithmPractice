using System.Collections.Generic;
using System.Linq;

namespace AlgorithmAnalysis
{
    // Do not alter method signatures
    public static class Algorithms1
    {
        /* Problem: Create a function that returns whether or not a given growth rate table is valid
         * A table is valid if:
         *      It spans all weeks 1 through 53.
         *      Each row can have multiple weeks. 
         *      All rows cover a time period moving forward
         *      No overlapping weeks appear in the table. 
         *      The sum of all growth percentages in the table is equal to 1
         *  Example Valid Table:
         *      Row Index   StartWeek   EndWeek     GrowthPct
         *      1           1           4           .1
         *      2           8           10          .17
         *      3           5           7           .05
         *      4           11          53          .68
         *  Other notes:
         *      The table does not have a guaranteed order or data values
         *      You may use any .NET functions available to you or build additional structures if necessary
         *      The order of priorities for the solution should be: Correctness, Elegance/Style, and Performance.
        */

        /// <summary>
        /// Validates through series of helper methods wether a growth table is valid or not.
        /// </summary>
        /// <param name="t">Growth table</param>
        /// <returns>Valid/invalid true false</returns>
        public static bool IsValid(GrowthTable t)
        {
            // Check if table spans all weeks from 1 to 53
            if (!SpansAllWeeks(t))
            {
                return false;
            }

            // Check if each row covers a time period moving forward and has no overlapping weeks
            if (!NoOverlappingWeeks(t))
            {
                return false;
            }

            // Check if the sum of all growth percentages equals 1
            if (!SumOfGrowthPctsEquals1(t))
            {
                return false;
            }

            // Table is valid
            return true;
        }

        /// <summary>
        /// Confirming growth table spans all weeks
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Valid/invalid true false</returns>
        private static bool SpansAllWeeks(GrowthTable t)
        {
            var coveredWeeks = t.Rows.SelectMany(row => Enumerable.Range(row.StartWeek, row.EndWeek - row.StartWeek + 1)).ToList();
            return coveredWeeks.Count == 53 && coveredWeeks.Distinct().Count() == 53;
        }

        /// <summary>
        /// Confirming no overlapping weeks in growth table
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Valid/invalid true false</returns>
        private static bool NoOverlappingWeeks(GrowthTable t)
        {
            var allWeeks = new HashSet<int>();
            foreach (var row in t.Rows)
            {
                for (int week = row.StartWeek; week <= row.EndWeek; week++)
                {
                    if (!allWeeks.Add(week))
                    {
                        // Found overlapping week
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Confirms/denies growth table percentage equals 100%
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Valid/invalid true false</returns>
        private static bool SumOfGrowthPctsEquals1(GrowthTable t)
        {
            decimal sum = t.Rows.Sum(row => row.GrowthPct);
            return sum == 1m;
        }
    }

    /// <summary>
    /// Growth table is a collection of Growth table rows.
    /// </summary>
    public class GrowthTable
    {
        public List<GrowthTableRow> Rows { get; set; }

        public GrowthTable() { }

        public GrowthTable(List<GrowthTableRow> rows)
        {
            Rows = rows;
        }
    }

    /// <summary>
    /// Member of growrth table, specifies start week/end week and total growth percentage of this quarter/row.
    /// Use constructor to instantiate.
    /// </summary>
    public class GrowthTableRow
    {
        public int StartWeek { get; set; }
        public int EndWeek { get; set; }

        /// <summary>
        /// must be 1.0 for a valid result. anything else invalid
        /// </summary>
        public decimal GrowthPct { get; set; }

        public GrowthTableRow() { }

        public GrowthTableRow(int start, int end, decimal growth)
        {
            StartWeek = start;
            EndWeek = end;
            GrowthPct = growth;
        }
    }
}
