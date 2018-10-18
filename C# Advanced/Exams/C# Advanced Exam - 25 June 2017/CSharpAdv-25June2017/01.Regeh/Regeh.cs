using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Regeh
    {
        static void Main()
        {
            string text = Console.ReadLine();
            /*HAD ERROR: HAD COPY-PASTED OPENING, BUT NOT CLOSING SQUARE BRACKED */
            Regex pattern = new Regex(@"\[([^\s\[]+)\<(?<index1>[0-9]+)REGEH(?<index2>[0-9]+)\>([^\s\]]+)\]");
            MatchCollection matches = pattern.Matches(text);
            var indexes = new List<int>();

            foreach(Match match in matches)
            {
                var groups = match.Groups;
                int index_1 = int.Parse(groups["index1"].Value);
                int index_2 = int.Parse(groups["index2"].Value);

                indexes.Add(index_1);
                indexes.Add(index_2);
            }

            int currentIndex = 0;
            StringBuilder result = new StringBuilder();

            foreach(int index in indexes)
            {
                currentIndex += index;

                if(currentIndex >= text.Length)
                {
                    int temp = currentIndex - text.Length + 1;
                    currentIndex = 0;
                    currentIndex += temp;
                }
                result.Append(text[currentIndex]);
            }
            Console.WriteLine(result);
        }
    }
}