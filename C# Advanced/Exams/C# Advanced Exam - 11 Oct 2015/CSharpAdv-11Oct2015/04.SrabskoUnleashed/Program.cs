using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var concertData = new Dictionary<string, Dictionary<string, int>>();

            while(input != "End")
            {
                var tokens = input.Split('@');

                if(tokens.Length == 2)
                {
                    var name_part = tokens[0].Split(new char[] { ' ' },
                                                    StringSplitOptions.RemoveEmptyEntries);
                    var other_data = tokens[1].Split(new char[] { ' ' },
                                                    StringSplitOptions.RemoveEmptyEntries);


                    string name = String.Join(" ", name_part);
                    string venue = "";

                    if (other_data.Length > 3)
                    {
                        venue = String.Join(" ", other_data.SkipLast(2));

                        if(concertData.ContainsKey(venue) == false)
                        {
                            concertData.Add(venue, new Dictionary<string, int>());
                        }

                        if(concertData[venue].ContainsKey(name) == false)
                        {
                            concertData[venue].Add(name, 0);
                        }

                        concertData[venue][name]
                    }
                    // Console.WriteLine(String.Join(" => ", tokens));
                    // Console.WriteLine(name_part);
                    //Console.WriteLine(name);
                    // Console.WriteLine(venue);
                }

                

                input = Console.ReadLine();
            }
        }
    }
}
