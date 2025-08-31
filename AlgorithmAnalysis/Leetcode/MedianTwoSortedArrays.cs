using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Leetcode
{
    /// <summary>
    /// Provides an O(log(m+n)) algorithm to find the median of two sorted arrays.
    /// </summary>
    public static class MedianTwoSortedArrays
    {
        /// <summary>
        /// Finds the median of two sorted integer arrays.
        /// Time complexity: O(log(min(m, n))). Space complexity: O(1).
        /// </summary>
        /// <param name="nums1">First sorted array.</param>
        /// <param name="nums2">Second sorted array.</param>
        /// <returns>The median value as a double.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either array is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when inputs are not sorted or some invariant breaks.</exception>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null) throw new ArgumentNullException(nameof(nums1));
            if (nums2 == null) throw new ArgumentNullException(nameof(nums2));

            // Ensure nums1 is the smaller array to keep the binary search bounds tight.
            if (nums1.Length > nums2.Length)
            {
                (nums1, nums2) = (nums2, nums1);
            }

            int m = nums1.Length;
            int n = nums2.Length;

            int totalLeft = (m + n + 1) / 2; // number of elements on the left side of the partition
            int lo = 0, hi = m;

            while (lo <= hi)
            {
                int i = (lo + hi) / 2;       // partition in nums1
                int j = totalLeft - i;       // corresponding partition in nums2

                int nums1LeftMax = (i == 0) ? int.MinValue : nums1[i - 1];
                int nums1RightMin = (i == m) ? int.MaxValue : nums1[i];

                int nums2LeftMax = (j == 0) ? int.MinValue : nums2[j - 1];
                int nums2RightMin = (j == n) ? int.MaxValue : nums2[j];

                if (nums1LeftMax <= nums2RightMin && nums2LeftMax <= nums1RightMin)
                {
                    // Correct partition
                    if (((m + n) % 2) == 1)
                    {
                        return Math.Max(nums1LeftMax, nums2LeftMax);
                    }
                    else
                    {
                        int leftMax = Math.Max(nums1LeftMax, nums2LeftMax);
                        int rightMin = Math.Min(nums1RightMin, nums2RightMin);
                        return (leftMax + rightMin) / 2.0;
                    }
                }
                else if (nums1LeftMax > nums2RightMin)
                {
                    // i is too big, move left
                    hi = i - 1;
                }
                else
                {
                    // i is too small, move right
                    lo = i + 1;
                }
            }

            throw new InvalidOperationException("Invalid input: arrays may not be sorted.");
        }
    }
}
