using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string text = Console.ReadLine();
            var symbolsData = new Dictionary<char, int>();

            for (int index = 0; index < text.Length; index++)
            {
                char symbol = text[index];

                if (symbolsData.ContainsKey(symbol) == false)
                {
                    symbolsData.Add(symbol, 0);
                }

                symbolsData[symbol]++;
            }

            var orderedSymbolsData = symbolsData.OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbolPair in orderedSymbolsData)
            {
                char symbol = symbolPair.Key;
                int occurs = symbolPair.Value;

                Console.WriteLine($"{symbol}: {occurs} time/s");
            }
        }
    }
}