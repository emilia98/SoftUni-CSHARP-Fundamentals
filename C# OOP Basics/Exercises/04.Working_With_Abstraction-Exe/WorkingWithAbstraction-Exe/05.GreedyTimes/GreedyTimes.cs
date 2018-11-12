using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GreedyTimes
{
    public class GreedyTimes
    {
        static void Main()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, 
                                                     StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0; 
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long count = long.Parse(safe[i + 1]);

                string item = string.Empty;

                if (name.Length == 3)
                {
                    item = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    item = "Gold";
                }

                if (item == "")
                {
                    continue;
                }
                else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                bool hasThisItem = bag.ContainsKey(item);

                switch (item)
                {
                    case "Gem":
                        double totalGold = 0;
                        bool hasAnyGold = bag.ContainsKey("Gold");

                        if (hasAnyGold)
                        {
                            totalGold = bag["Gold"].Values.Sum();
                        }

                        if (!hasThisItem)
                        {
                            if (hasAnyGold)
                            {
                                if (count > totalGold)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > totalGold)
                        {
                            continue;
                        }
                        break;

                    case "Cash":
                        double totalGems = 0;
                        bool hasAnyGems = bag.ContainsKey("Gem");

                        if (hasAnyGems)
                        {
                            totalGems = bag["Gem"].Values.Sum();
                        }

                        if (!hasThisItem)
                        {
                            if (hasAnyGems)
                            {
                                if (count > totalGems)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + count > totalGems)
                        {
                            continue;
                        }
                        break;
                }

                if (!hasThisItem)
                {
                    bag[item] = new Dictionary<string, long>();
                }

                if (!bag[item].ContainsKey(name))
                {
                    bag[item][name] = 0;
                }

                bag[item][name] += count;
                if (item == "Gold")
                {
                    gold += count;
                }
                else if (item == "Gem")
                {
                    gems += count;
                }
                else if (item == "Cash")
                {
                    cash += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}