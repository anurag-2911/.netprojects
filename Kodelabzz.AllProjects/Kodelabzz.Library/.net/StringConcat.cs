using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodelabzz.Library.net
{
    public class StringConcat
    {
        public static void Run()
        {
            //StringTest();
            StringBuilderTest();
        }

        private static void StringTest()
        {
            string result = string.Empty;
            for (int i = 0; i < 10000; i++)
            {
                result += "hi";
            }
        }
        private static void StringBuilderTest()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                result.Append("hi");
            }
        }
    }
}
