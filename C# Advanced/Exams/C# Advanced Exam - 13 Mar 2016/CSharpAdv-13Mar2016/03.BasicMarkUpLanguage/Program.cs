using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.BasicMarkUpLanguage
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            var lines = new List<string>();
            Regex inverse_pattern = new Regex(@"\<\s*inverse\s*content\s*=\s*""(?<content>[^""]+?)""\s*\/\s*\>");
            Regex reverse_pattern = new Regex(@"\<\s*reverse\s*content\s*=\s*""(?<content>[^""]+?)""\s*\/\s*\>");
            Regex repeat_pattern = new Regex(@"\<\s*repeat\s*(((?<value>value\s*=\s*""[0 - 9] +?"")\s* (?<content>content\s*=\s*""[^""]+""))|((?<content2>content\s*=\s*""[^""]+"")\s*(?<value2>value\s*=\s*""[0-9]+?"")))\s*\/\s*\>");

            while (command != "<stop/>")
            {
                Match match = null;

                if (inverse_pattern.IsMatch(command))
                {
                    match = inverse_pattern.Match(command);
                    lines.Add(Inverse(match));
                }
                else if(reverse_pattern.IsMatch(command))
                {
                    match = reverse_pattern.Match(command);
                    lines.Add(Reverse(match));
                } 
                command = Console.ReadLine();
            }
        }

        static string Inverse(Match match)
        {
            string content = match.Groups["content"].Value;
            StringBuilder result = new StringBuilder();

            for(int index = 0; index < content.Length; index++)
            {
                char symbol = content[index];

                if(symbol >= 'a' && symbol <= 'z')
                {
                    symbol = (char)((int)symbol - 32);
                }
                else if(symbol >= 'A' && symbol <= 'Z')
                {
                    symbol = (char)((int)symbol + 32);
                }
                result.Append(symbol);
            }

            return result.ToString();
        }

        static string Reverse(Match match)
        {
            string content = match.Groups["content"].Value;
            StringBuilder result = new StringBuilder();

            for (int index = content.Length - 1; index >= 0; index--)
            {
                char symbol = content[index];
                result.Append(symbol);
            }

            return result.ToString();
        }
    }
}
