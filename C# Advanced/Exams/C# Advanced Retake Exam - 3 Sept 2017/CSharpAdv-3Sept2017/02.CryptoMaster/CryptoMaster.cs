using System;
using System.Linq;

namespace _02.CryptoMaster
{
    class CryptoMaster
    {
        static void Main()
        {
            var inputArray = Console.ReadLine().Split(new char[] { ',', ' ' },
                                                      StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray();
            int step = 1;
            int length = inputArray.Length;
            int maxLength = 0;
            int currentLength = 0;

            int prevElement;
            int currentElement = inputArray[0];
            int index;
            int iter;

            while (step < length)
            {
                iter = 0;

                while (iter < length)
                {
                    currentLength = 1;
                    currentElement = inputArray[iter];
                    index = iter + step;
                    if (index >= length)
                    {
                        index -= length;
                    }
                    
                    while (true)
                    {
                        prevElement = currentElement;
                        currentElement = inputArray[index];

                        if (currentElement > prevElement)
                        {
                            currentLength++;
                        }
                        else
                        {
                            break;
                        }

                        index += step;
                        
                        if (index >= length)
                        {
                            index -= length;
                        }
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                    iter++;
                }
                step++;
            }
            
            Console.WriteLine(maxLength);
        }
    }
}