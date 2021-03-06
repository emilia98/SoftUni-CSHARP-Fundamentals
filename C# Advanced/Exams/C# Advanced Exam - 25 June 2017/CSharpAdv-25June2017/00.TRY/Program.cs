﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightGame
{
    class Program
    {
        static int n;
        static char[][] grid;
        static Dictionary<int, Dictionary<int, int>> indexer = new Dictionary<int, Dictionary<int, int>>();
        static Dictionary<int, List<int>> stats = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            grid = new char[n][];

            int uniqueIndex = 1;
            for (int row = 0; row < n; row++)
            {
                grid[row] = Console.ReadLine().ToCharArray();
                indexer.Add(row, new Dictionary<int, int>());

                for (int col = 0; col < grid[row].Length; col++)
                {
                    indexer[row][col] = uniqueIndex;
                    uniqueIndex++;
                }
            }


            for (int row = 0; row < n; row++)
            {
                // indexer.Add(row, new Dictionary<int, int>());

                for (int col = 0; col < n; col++)
                {
                    uniqueIndex = indexer[row][col];
                    // Console.WriteLine(indexer[row][col]);
                    char figure = grid[row][col];

                    if (figure == 'K')
                    {
                        Attack(row, col, uniqueIndex);
                    }

                }
            }

            // Console.WriteLine("asfsafsaf");

            /*
            foreach(var pair in stats)
            {
                Console.WriteLine(pair.Key);
                Console.WriteLine(String.Join(" ", pair.Value));
                Console.WriteLine();
            }
           */

            int removed = 0;
            var orderedStats = stats.OrderByDescending(x => x.Value.Count)
                                    .ToDictionary(x => x.Key, x => x.Value);

            /*
            foreach(var pair in orderedStats)
            {
                Console.WriteLine("{0} <=> {1}", pair.Key, pair.Value);
            }
            */
            int pos = 0;

            while(orderedStats.Count > 0)
            {
                removed++;
                var pair = orderedStats.ElementAt(pos);
                int currentIndex = pair.Key;
                var elements = pair.Value;

                // Console.WriteLine("**********");
                int elementsCounter = elements.Count;
                for (int index = 0; index < elementsCounter; index++)
                {
                    int customIndex = elements[index];
                    elements[index] = -1;

                    //  Console.WriteLine("CI = " + customIndex);
                    //Console.WriteLine(orderedStats.ContainsKey(customIndex));
                    //Console.WriteLine();
                    //Console.WriteLine(String.Join(" ", orderedStats.));
                    // Console.WriteLine(String.Join(" ", elements));
                    orderedStats[customIndex].Remove(currentIndex);

                    if (orderedStats[customIndex].Count == 0)
                    {
                        orderedStats.Remove(customIndex);
                    }

                    /*
                    if (orderedStats.Count == 0)
                    {
                        break;
                    }
                    */
                }

                elements = elements.Where(x => x != -1).ToList();

                if (elements.Count == 0)
                {
                    // Console.WriteLine("here");
                    orderedStats.Remove(currentIndex);
                }

                if (orderedStats.Count == 0)
                {
                    break;
                }

                orderedStats = orderedStats.OrderByDescending(x => x.Value.Count())
                                    .ToDictionary(x => x.Key, x => x.Value);
                // pos = 0;
            }

            // Console.WriteLine(removed);
            /*
            for(int pos = 0; pos < orderedStats.Count(); pos++)
            {
                var pair = orderedStats.ElementAt(pos);
                int currentIndex = pair.Key;
                var elements = pair.Value;

                // Console.WriteLine(String.Join(" ", elements));
                int elementsCounter = elements.Count;
                for(int index = 0; index < elementsCounter; index++)
                {
                    int customIndex = elements[index];
                    elements[index] = -1;
                    // Console.WriteLine("CI : " + currentIndex);
                    orderedStats[customIndex].Remove(currentIndex);

                    if (orderedStats[customIndex].Count == 0)
                    {
                        orderedStats.Remove(customIndex);
                        // pos = -1;

                    }

                    if (orderedStats.Count == 0)
                    {
                        break;
                    }
                   // Console.WriteLine(String.Join(" ", elements));
                }

                 elements = elements.Where(x => x != -1).ToList();

                if (elements.Count == 0)
                {
                    orderedStats.Remove(currentIndex);
                    // pos = 0;
                }

                if (orderedStats.Count == 0)
                {
                    break;
                }

                
            }
            */
            /*
            for(int pos = 0; pos < orderedStats.Count; pos++)
            {
                removed++;

                var pair = orderedStats.ElementAt(pos);
                int currentIndex = pair.Key;
                var elements = pair.Value;

                // Console.WriteLine(String.Join(" ", elements));
                for (int index = 0; index < elements.Count; index++)
                {
                    int customIndex = elements[index];
                    elements[index] = -1;
                    orderedStats[customIndex].Remove(currentIndex);

                   
                    // Console.WriteLine(45);

                    if (orderedStats[customIndex].Count == 0)
                    {
                        orderedStats.Remove(customIndex);
                       //  keys.Remove(keys.IndexOf(customIndex));
                    }


                    if (orderedStats.Count == 0)
                    {
                        break;
                    }
                    // Console.WriteLine("ola");
                }

               // Console.WriteLine(String.Join(" ", elements));

                elements = elements.Where(x => x != -1).ToList();

                //Console.WriteLine(String.Join(" ", elements));

                //Console.WriteLine();
                if (elements.Count == 0)
                {
                    orderedStats.Remove(currentIndex);
                }

                if (orderedStats.Count == 0)
                {
                    break;
                }

                // orderedStats = stats.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            }
            */
            /*
            var keys = orderedStats.Keys.ToList();
            foreach (var key in keys)
            {
                Console.WriteLine("KEY {0}", key);
                

                int currentIndex = key;
                var elements = orderedStats[key];

               //  Console.WriteLine(String.Join(" ", elements));
                for (int index = 0; index < elements.Count; index++)
                {
                    int customIndex = elements[index];
                    elements[index] = -1;
                    orderedStats[customIndex].Remove(currentIndex);

                    // Console.WriteLine(45);

                    if (orderedStats[customIndex].Count == 0)
                    {
                        orderedStats.Remove(customIndex);
                        keys.Remove(keys.IndexOf(customIndex));
                    }

                    
                    if (orderedStats.Count == 0)
                    {
                        break;
                    }
                    // Console.WriteLine("ola");
                }

                elements = elements.Where(x => x != -1).ToList();

                if (elements.Count == 0)
                {
                    orderedStats.Remove(currentIndex);
                }

                if (orderedStats.Count == 0)
                {
                    break;
                }

            }

            /*
            foreach (var pair in orderedStats)
            {
                removed++;

                int currentIndex = pair.Key;
                var elements = pair.Value;

                Console.WriteLine(String.Join(" ", elements));
                for (int index = 0; index < elements.Count; index++)
                {
                    int customIndex = elements[index];
                    elements[index] = -1;
                    orderedStats[customIndex].Remove(currentIndex);

                    Console.WriteLine(45);
                    
                    if (orderedStats[customIndex].Count == 0)
                    {
                        // orderedStats[customIndex] = null;
                        Console.WriteLine("Here");
                        orderedStats.Remove(customIndex);
                    }
                    
                    
                    if (stats.Count == 0)
                    {
                        break;
                    }
                    Console.WriteLine("ola");
                }

                elements = elements.Where(x => x != -1).ToList();

                if (elements.Count == 0)
                {
                    orderedStats.Remove(currentIndex);
                }

                if (orderedStats.Count == 0)
                {
                    break;
                }

            }
*/
            Console.WriteLine(removed);

        }

        static void Attack(int row, int col, int uniqueIndex)
        {
            if (stats.ContainsKey(uniqueIndex) == false)
            {
                stats.Add(uniqueIndex, new List<int>());
            }


            // 1 up <-> 2 left
            if (IsInMatrix(row - 1, col - 2))
            {
                CheckTheMove(row - 1, col - 2, uniqueIndex);
            }

            // 1 up <-> 2 right
            if (IsInMatrix(row - 1, col + 2))
            {
                CheckTheMove(row - 1, col + 2, uniqueIndex);
            }

            // 1 down <-> 2 left
            if (IsInMatrix(row + 1, col - 2))
            {
                CheckTheMove(row + 1, col - 2, uniqueIndex);
            }

            // 1 down <-> 2 right
            if (IsInMatrix(row + 1, col + 2))
            {
                CheckTheMove(row + 1, col + 2, uniqueIndex);
            }

            // 1 left <-> 2 up
            if (IsInMatrix(row - 2, col - 1))
            {
                CheckTheMove(row - 2, col - 1, uniqueIndex);
            }

            // 1 left -> 2 down
            if (IsInMatrix(row + 2, col - 1))
            {
                CheckTheMove(row + 2, col - 1, uniqueIndex);
            }

            // 1 right <-> 2 up
            if (IsInMatrix(row - 2, col + 1))
            {
                CheckTheMove(row - 2, col + 1, uniqueIndex);
            }

            // 1 right -> 2 down
            if (IsInMatrix(row + 2, col + 1))
            {
                CheckTheMove(row + 2, col + 1, uniqueIndex);
            }

            
            if (stats[uniqueIndex].Count == 0)
            {
                stats.Remove(uniqueIndex);
            }
            

        }

        static void CheckTheMove(int row, int col, int uniqueIndex)
        {
            // Console.WriteLine(row);
            char ch = grid[row][col];

            if (ch == 'K')
            {
                //  Console.WriteLine(indexer[row].Values);
                int index = indexer[row][col];

                /*
                if (stats.ContainsKey(index) == false)
                {
                    stats.Add(index, new List<int>());
                } */
                stats[uniqueIndex].Add(index);
                // stats[index].Add(uniqueIndex);
            }
        }

        static bool IsInMatrix(int row, int col)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }
            return true;
        }
    }
}
