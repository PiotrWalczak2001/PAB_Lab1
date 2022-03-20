using System;

namespace Lab1_ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3.Przepisz program na Java https://dirask.com/posts/JavaScript-binary-search-algorithm-example-gp5lgD
            Console.WriteLine("Lab1 Ex3");
            var array = new int[] { 4, 5, 7, 11, 12, 15, 15, 21, 40, 45 };
            
            int searchIndex(int[] array, int value)
            {
                var index = 0;
                var limit = array.Length - 1;
                while (index <= limit)
                {
                    decimal sum = index + limit;
                    var point = Math.Ceiling(sum/ 2);
                    int result;
                    int.TryParse(point.ToString(), out result);
                    var entry = array[result];
                    if (value > entry)
                    {
                        index = result + 1;
                        continue;
                    }
                    if (value < entry)
                    {
                        limit = result - 1;
                        continue;
                    }
                    return index;
                }
                Console.WriteLine(index);
                return index;
            }

            Console.WriteLine(searchIndex(array,11));
        }
    }
}
