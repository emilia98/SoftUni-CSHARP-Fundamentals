using System;
using System.Collections;

namespace Previous_ArrayList
{
    public class StartUp
    {
        public static void Main()
        {
            ArrayList listOfNumbers = new ArrayList();

            listOfNumbers.Add(1);
            listOfNumbers.Add(2);
            listOfNumbers.Add(16.5);
            listOfNumbers.Add("Pesho");

            var result = listOfNumbers[3];
            Console.WriteLine(result);

            var result2 = (int)listOfNumbers[1];
            Console.WriteLine(result2);

            // result2 = (double)listOfNumbers[2];
            try
            {
                result2 = (int)listOfNumbers[2];
                Console.WriteLine(result2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}