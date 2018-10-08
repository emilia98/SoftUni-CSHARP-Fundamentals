using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06.Wardrobe
{
    class Wardrobe
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var clothesData = new Dictionary<string, Dictionary<string, int>>();

            for (int cnt = 1; cnt <= n; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = Regex.Split(input, @"\s*\-\>\s*");

                string color = tokens[0].Trim();
                var clothes = Regex.Split(tokens[1], @"\s*,\s*");

                if (clothesData.ContainsKey(color) == false)
                {
                    clothesData.Add(color, new Dictionary<string, int>());
                }

                foreach (var piece in clothes)
                {
                    if (clothesData[color].ContainsKey(piece) == false)
                    {
                        clothesData[color].Add(piece, 0);
                    }

                    clothesData[color][piece] = clothesData[color][piece] + 1;
                }

            }

            string[] itemToFind = Console.ReadLine()
                                         .Split(new char[] { ' ' },
                                                StringSplitOptions.RemoveEmptyEntries);
            string itemColor = itemToFind[0];
            string itemName = itemToFind[1];

            foreach (var pair in clothesData)
            {
                string color = pair.Key;
                var clothes = pair.Value;

                Console.WriteLine("{0} clothes:", color);

                foreach (var pieceData in clothes)
                {
                    string type = pieceData.Key;
                    int quantity = pieceData.Value;

                    string found = "";

                    if (itemName == type && itemColor == color)
                    {
                        found = " (found!)";
                    }

                    Console.WriteLine($"* {type} - {quantity}{found}");
                }
            }
        }
    }
}