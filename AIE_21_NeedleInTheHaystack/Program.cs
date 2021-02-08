using System;
using System.Linq;

namespace AIE_21_NeedleInTheHaystack
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new string[] { "hay", "junk", "hay", "hay", "moreJunk", "needle", "randomJunk" };
            var needleLocation = FindNeedle(strings);
            if (needleLocation < 0)
            {
                Console.WriteLine("did not find needle");
            }
            else
            {
                Console.WriteLine(needleLocation);
            }
        }
        private static int FindNeedle(string[] haystack)
        {
            return Array.FindIndex(haystack, hay => hay == "needle");
        }
    }
}
