namespace MaximumSubarraySum
{
    // Given an array of N numbers, find the contiguous subarray with the maximum sum.
    // A subarray is optimal only if it carries no negative prefix or suffix, so we can
    // greedily drop the running sum back to zero whenever it goes negative: Kadane's
    // algorithm, O(n) time, O(1) space.
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] example1 = [1, 2, -5, 6, 3, -1, 4, -2, 3, 3, -2, 3];
            int[] example2 = [3, -2, 3, 3, -2, 4, -1, 5, 6, -5, 2, 1];

            Console.WriteLine($"Example 1 max subarray sum: {MaxSubArray(example1)}");
            Console.WriteLine($"Example 2 max subarray sum: {MaxSubArray(example2)}");
        }

        public static int MaxSubArray(int[] nums)
        {
            int bestSum = nums[0];
            int currentSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                bestSum = Math.Max(bestSum, currentSum);
            }

            return bestSum;
        }
    }
}
