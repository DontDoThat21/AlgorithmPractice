using System.Collections.Generic;
using System.Linq;

namespace AlgorithmAnalysis
{
    /// <summary>
    /// Provides methods for sorting a list of people by last name first name and age.
    /// </summary>
    public class Algorithms3
    {
        /// <summary>
        /// Sorts a list of people by last name first name and age with LINQ.
        /// </summary>
        /// <returns>sorted list of people</returns>
        public static List<string> SortByLastNameThenFirstName()
        {
            var sortedList = _People
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .Select(p => $"{p.LastName} - {p.FirstName} - {p.Age}")
                .ToList();

            return sortedList;
        }

        /// <summary>
        /// Counts the occurrences of each unique first name in the list of people.
        /// </summary>
        /// <returns>
        /// list of strings representing each unique first name along with its ocurrence count.
        /// </returns>
        public static List<string> CountsByFirstName()
        { // linq expression to get counts of first name ocurrences
            var countsList = _People
                .GroupBy(p => p.FirstName)
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key}, {g.Count()}")
                .ToList();

            return countsList;
        }

        // example data (not pulling from, i.e., a database)
        public static List<Person> _People =
            new List<Person> {
            new Person { FirstName = "Amy", LastName="Monroe", Age = 54},
            new Person { FirstName = "Amy", LastName="Duval", Age = 54},
            new Person { FirstName = "Joe", LastName="Conrad", Age = 14},
            new Person { FirstName = "Amy", LastName="Jenkins", Age = 34},
            new Person { FirstName = "Bill", LastName="Monroe", Age = 34},
            new Person { FirstName = "Amy", LastName="Smith", Age = 34},
            new Person { FirstName = "Joe", LastName="Johnson", Age = 14},
            new Person { FirstName = "Tom", LastName="Jones", Age = 45},
            new Person { FirstName = "Emily", LastName="Brown", Age = 28},
            new Person { FirstName = "John", LastName="Doe", Age = 40}
        };

        /// <summary>
        /// Represents a person object type for above sorting operations.
        /// </summary>
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}
