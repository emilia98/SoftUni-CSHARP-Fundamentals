using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class HitList
    {
        static Dictionary<string, Dictionary<string, string>> peopleData;

        static void Main()
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            peopleData = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while(input != "end transmissions")
            {
                var tokens = input.Split(new char[] { '=' }, 
                                         StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                var pairs = String.Join("", tokens.Skip(1))
                                  .Split(new char[] { ';' },
                                         StringSplitOptions.RemoveEmptyEntries);
                
                if(peopleData.ContainsKey(name) == false)
                {
                    peopleData.Add(name, new Dictionary<string, string>());
                }

                FillPersonalData(name, pairs);
                input = Console.ReadLine();
            }

            string toKill = Console.ReadLine().Replace("Kill ", "");
            var person = peopleData[toKill];

            var sortedByKey = person.OrderBy(x => x.Key)
                                    .ToDictionary(x => x.Key, x => x.Value);
            int infoIndex = 0;

            Console.WriteLine("Info on {0}:", toKill);

            foreach(var data in sortedByKey)
            {
                string key = data.Key;
                string value = data.Value;

                infoIndex += (key.Length + value.Length);

                Console.WriteLine($"---{key}: {value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if(infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int infoNeeded = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }

        static void FillPersonalData(string name, string[] pairs)
        {
            foreach (var pair in pairs)
            {
                var tokens = pair.Split(new char[] { ':' },
                                        StringSplitOptions.RemoveEmptyEntries);
                string key = tokens[0];
                string value = tokens[1];


                peopleData[name][key] = value;
            }
        }
    }
}