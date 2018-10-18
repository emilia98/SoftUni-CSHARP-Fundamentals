using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _00.TRY
{
    class Program
    {
        static void Main()
        {
            var inputArray = Console.ReadLine().Split(new char[] { ',', ' ' },
                                                      StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray();
            int step = 1;
            int length = inputArray.Length;
            //var maxSeq = new List<int>();

            int maxLength = 0;

            /*
            var initArrayData = new Dictionary<int, int[]>();
            int iter = 0;
            var asQueue = new Queue<int>(inputArray);
            //initArrayData.Add(0, )
            //
            while(iter < length)
            {
                initArrayData.Add(iter, asQueue.ToArray());
                asQueue.Enqueue(asQueue.Dequeue());
                iter++;
            }*/
            
            /*
            foreach (var pair in initArrayData)
            {
                Console.WriteLine(String.Join(" ", pair.Value));
            }
            Console.WriteLine();
            */

            // var seq = initArrayData[0];
            int currentLength;
            int prevElement;
            int currentElement = inputArray[0];
            // var uniqueIndexes = new List<int>();
            int index;
            int iter;

            while (step < length)
            {
                iter = 0;
                // int iter = 0;
                // var seq = new Queue<int>(inputArray);

                //Console.WriteLine("Step = " + step);
                while(iter < length)
                {
                    // seq = initArrayData[iter];
                    //  var currentSeq = new Stack<int>();

                    currentLength = 1;

                    // var seqAsArray = seq.ToList();
                    // prevElement;
                    // currentElement = seq[0];
                    currentElement = inputArray[iter];

                    // currentSeq.Push(currentElement);
                   index = iter + step;
                    if (index >= length)
                    {
                        index -= length;
                    }

                    //uniqueIndexes = new List<int>();

                    while (true)
                    { // Console.WriteLine("Index = " + index);

                        // total++;
                        prevElement = currentElement;
                        currentElement = inputArray[index];
                        // int prevElement = currentSeq.Peek();

                        //Console.WriteLine("PE = " + prevElement);
                        // Console.WriteLine("{0} <-> {1}", currentElement, prevElement);
                        if (currentElement > prevElement)
                        {
                            currentLength++;
                        }
                        else
                        {
                            break;
                        }

                        index += step;

                       
                        if(index >= length)
                        {
                            index -= length;
                        } 

                        /*
                        if(uniqueIndexes.IndexOf(index) != -1)
                        {
                            break;
                        }
                        else
                        {
                            uniqueIndexes.Add(index);
                        }*/
                    }

                    //Console.WriteLine();
                   // Console.WriteLine(currentLength);
                    //Console.WriteLine("SEQ");
                    //Console.WriteLine(String.Join(" ", currentSeq));
                    //Console.WriteLine();

                    /*
                    if (currentSeq.Count >= maxSeq.Count)
                    {
                        maxSeq = currentSeq.ToList();
                    }
                    */

                    if(currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }

                    // seq.Enqueue(seq.Dequeue());

                    iter++;
                }
                step++;
            }

            // Console.WriteLine(String.Join(" ", maxSeq));
            Console.WriteLine(maxLength);
            // Console.WriteLine(total);

           // Process proc = Process.GetCurrentProcess();
            //Console.WriteLine(proc.PrivateMemorySize64);
        }
    }
}
