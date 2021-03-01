using System;
using System.Linq;

namespace NextLargestInteger
{
	class Program
	{
		static void Main(string[] args)
		{
            int[] values = new int[] { 7895, 534976, 218765, 537986, 785, 4785, 1234, 4321 };

			values.ToList()
				.ForEach(number =>
				{
					Console.WriteLine($"{number} => {NextBiggestNumber(number)}");
				});
		}

		private static int NextBiggestNumber(int number)
		{
			char[] numbers = number.ToString().ToCharArray();
			char[] answer = new char[numbers.Length];
            char[] remainder = null;
			int hit = -1;

			for (int i = numbers.Length - 1; i > 0; i--)
			{
                if (numbers[i] > numbers[i - 1])
				{
                    hit = i - 1;
                    remainder = numbers.AsSpan(hit).ToArray();
                    break;
				}
			}

			if (hit == -1)
				return number;

            Array.Sort(remainder);
            char target = remainder.First(y => y > numbers[hit]);
            Array.Copy(numbers, answer, hit);
            answer[hit] = target;

            var lastchars = remainder.Where(y => y != target).ToArray();
            Array.Sort(lastchars);

            Array.Copy(lastchars, 0, answer, hit + 1, numbers.Length - hit - 1);

            return Convert.ToInt32(new string(answer));
		}
    }
}
