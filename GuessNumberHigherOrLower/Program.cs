namespace GuessNumberHigherOrLower
{
    // A number `num` between 1 and n is picked at random. guess(x) returns 0 if x == num,
    // -1 if x < num, and +1 if x > num. Find num with the minimum number of guesses in the
    // worst case: binary search, O(log n).
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int target in new[] { 1, 69, 1000 })
            {
                Oracle oracle = new(target, upperBound: 1000);
                int found = GuessNumber(1000, oracle.Guess);

                Console.WriteLine(
                    $"Target: {target,4} | Found: {found,4} | Guesses used: {oracle.CallCount}");
            }
        }

        public static int GuessNumber(int n, Func<int, int> guess)
        {
            int left = 1;
            int right = n;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int result = guess(mid);

                if (result == 0)
                {
                    return mid;
                }

                if (result < 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            throw new InvalidOperationException("Number not found in range.");
        }

        private class Oracle(int num, int upperBound)
        {
            public int CallCount { get; private set; }

            public int Guess(int x)
            {
                CallCount++;

                if (x < 1 || x > upperBound)
                {
                    throw new ArgumentOutOfRangeException(nameof(x));
                }

                return x.CompareTo(num) switch
                {
                    0 => 0,
                    < 0 => 1,
                    > 0 => -1,
                };
            }
        }
    }
}
