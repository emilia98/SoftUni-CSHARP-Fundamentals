using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.RageQuit
{
    class RageQuit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"([^0-9]+)([0-9]+)");
            MatchCollection matches = pattern.Matches(input);

            List<char> charsUsed = new List<char>();
            /* HAD ERROR (Time Limit)
             * -> String concatination is too slow operations
            string result = String.Empty;
            */
            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                var groups = match.Groups;
                string str = groups[1].Value.ToUpper();
                int repeats = int.Parse(groups[2].Value);

                for(int cnt = 1; cnt <= repeats; cnt++)
                {
                    result.Append(str);
                }

                /* HAD ERROR: What if we have no repeats (repeats = 0)?
                 * -> We should NOT count unique chars, despite there are some.
                */

                if(repeats > 0)
                {
                    for (int index = 0; index < str.Length; index++)
                    {
                        char ch = str[index];

                        if (charsUsed.IndexOf(ch) == -1)
                        {
                            charsUsed.Add(ch);
                        }
                    }
                }
            }

            Console.WriteLine("Unique symbols used: {0}", charsUsed.Count);
            Console.WriteLine(result);
        }
    }
}
