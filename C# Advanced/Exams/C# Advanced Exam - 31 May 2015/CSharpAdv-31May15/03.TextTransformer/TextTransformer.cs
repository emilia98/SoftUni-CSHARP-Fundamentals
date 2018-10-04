using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03.TextTransformer
{
    class TextTransformer
    {
        /*
         * HAD ERROR (TIME & MEMORY LIMIT):
         * 1) StringBuilder is definately faster than string concatenation
         * 2) Appending many string to a List is slow
         */
        // static List<string> result = new List<string>();
        static StringBuilder currentString = new StringBuilder();

        static void Main()
        {
            StringBuilder text = new StringBuilder();
            string input = Console.ReadLine();

            while (input != "burp")
            {
                text.Append(input);
                input = Console.ReadLine();
            }

            var modifiedText = Regex.Replace(text.ToString(), @"\s+", " ");
            // HAD ERROR: With the regex (did match nested expressions with special characters at he both ends of each)
            var pattern = new Regex(@"(\$([^\$\%\&\']+)\$)|(\%([^\$\%\&\']+)\%)|(\&([^\$\%\&\']+)\&)|(\'([^\$\%\&\']+)\')");
            MatchCollection matches = pattern.Matches(modifiedText);
            
            foreach (Match match in matches)
            {
                string matchText = match.Value;
                char specialChar = matchText[0];
                string value = matchText.Substring(1, matchText.Length - 2);
                Decode(value, specialChar);
            }
            Console.WriteLine(currentString);
        }

        static void Decode(string value, char specialChar)
        {
            int specialCharValue = GetSpecialCharValue(specialChar);
            
            for (int index = 0; index < value.Length; index++)
            {
                char current = value[index];
                char decoded;

                if (index % 2 == 0)
                {
                    decoded = (char)(current + specialCharValue);
                }
                else
                {
                    decoded = (char)(current - specialCharValue);
                }

                currentString.Append(decoded);
            }

            currentString.Append(" ");
        }

        static int GetSpecialCharValue(char specialChar)
        {
            switch (specialChar)
            {
                case '$':
                    return 1;
                case '%':
                    return 2;
                case '&':
                    return 3;
                case '\'':
                    return 4;
            }
            return 0;
        }
    }
}