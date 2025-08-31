using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /* Problem: Create a function that returns search results back, focusing on performance.
         *  Example input parameter:
         *      1232,           1038,          4498,
         *      298,            8786,          1036,
         *      3132,           582,           7632,  
         *      4174,           1103,          5394
         *  Other notes:
         *      The table does not have a guaranteed order or data values
         *      The order of priorities for the solution should be: Performance, Elegance/Style, and Correctness.
        */
    public class Algorithms6
    {
        public Algorithms6()
        {

        }

        public static bool GetResultFromArray(int[] numbers, int search)
        {
            if(numbers.Contains(search))
                return true;
            return false;
        }

        public static bool GetResultFromArrayBST(int[] numbers, int search)
        {
            if (numbers.Contains(search))
                return true;
            return false;
        }
    }

    public class BinarySearchTree
    {
        public static List<BinarySearchTreeNode> tree = new List<BinarySearchTreeNode>();

        public static bool FindResultInBinarySearchTree(List<BinarySearchTreeNode> tree)
        {
            for (int i = 0; i < tree.Count; i++)
            {

            }
            return false;
        }
    }

    public class BinarySearchTreeNode
    {
        public static BinarySearchTreeNode child = null;
        public static BinarySearchTreeNode parent = null;
    }
}
