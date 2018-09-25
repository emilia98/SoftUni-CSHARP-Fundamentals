using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            var editor = new Stack<string>();
            string text = "";
            editor.Push(text);

            int n = int.Parse(Console.ReadLine());

            for (int cnt = 1; cnt <= n; cnt++)
            {
                string command = Console.ReadLine();
                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "1")
                {
                    string subtext = tokens[1];
                    text += subtext;
                    editor.Push(text);
                    continue;
                }

                if (tokens[0] == "2")
                {
                    int k = int.Parse(tokens[1]);
                    text = text.Substring(0, text.Length - k);
                    editor.Push(text);
                    continue;
                }

                if (tokens[0] == "3")
                {
                    int k = int.Parse(tokens[1]);

                    // Just in case, if we want a symbol on index that does not exist
                    if (k <= text.Length)
                    {
                        Console.WriteLine(text[k - 1]);
                    }
                    continue;
                }

                if (tokens[0] == "4")
                {
                    if (editor.Count == 1)
                    {
                        editor.Push("");
                    }

                    editor.Pop();
                    text = editor.Peek();
                }
            }
        }
    }
}
