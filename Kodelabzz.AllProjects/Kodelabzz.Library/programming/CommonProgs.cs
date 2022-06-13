using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodelabzz.Library.programming
{
    public class CommonProgs
    {
        public static void FindIfAllCharsAreUnique()
        {
            string word = "hello";
            HashSet<char> chars = new HashSet<char>();
            foreach (var item in word)
            {
                if(!chars.Contains(item))
                {
                    chars.Add(item);

                }
                else
                {
                    Console.WriteLine("not unique");
                }
            }
        }

        public static void FindSubarraWithGivenSum()
        {
            int n = 10, sum = 15;
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> output = SubarraySum(arr, 10, sum);
        }

        //Function to find a continuous sub-array which adds up to a given number.
        public static List<int> SubarraySum(int[] arr, int n, int s)
        {
            List<int> list = new List<int>();
           
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sum = sum + arr[j];
                    if(sum==s)
                    {
                        list.Add(i);
                        list.Add(j);
                    }
                }
            }

            return list;
        }
    }
}
