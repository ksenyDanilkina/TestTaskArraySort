using System;
using System.Linq;
using System.Text;

namespace TestTaskArraySort
{
    class Program
    {
        static void Main()
        {
            var array = GetSortedArrays(10);

            Console.WriteLine("Результат выполнения:");
            Console.WriteLine(GetArrayStrings(array));
        }

        public static int[][] GetSortedArrays(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"Index = {n}. Аргумент n должен быть > 0");
            }

            var resultArray = new int[n][];

            var rand = new Random();
            var arraySizes = new int[n];
            int nextArraySize;

            for (var i = 0; i < resultArray.Length; i++)
            {
                nextArraySize = rand.Next(n + 1);

                if (arraySizes.Any(x => x == nextArraySize))
                {
                    i--;
                    continue;
                }

                resultArray[i] = new int[nextArraySize];
                arraySizes[i] = nextArraySize;

                for (var j = 0; j < resultArray[i].Length; j++)
                {
                    resultArray[i][j] = rand.Next();
                }
            }

            for (var e = 0; e < resultArray.Length; e++)
            {
                if (e % 2 == 0)
                {
                    resultArray[e] = resultArray[e].OrderBy(x => x).ToArray();
                    continue;
                }

                resultArray[e] = resultArray[e].OrderByDescending(x => x).ToArray();
            }

            return resultArray;
        }

        public static string GetArrayStrings(int[][] array)
        {
            var stringBuilder = new StringBuilder();

            foreach (var e in array)
            {
                foreach (var k in e)
                {
                    stringBuilder.Append(k).Append(", ");
                }

                stringBuilder.Remove(stringBuilder.Length - 2, 2).AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
