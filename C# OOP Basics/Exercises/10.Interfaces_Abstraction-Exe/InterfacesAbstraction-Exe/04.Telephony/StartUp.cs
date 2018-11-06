using System;

namespace _04.Telephony
{
    public class StartUp
    {
        static void Main()
        {
            // No StringSplitOptions.RemoveEmptyEntries
            var phones = Console.ReadLine().Split(new char[] { ' ' });
            var urls = Console.ReadLine().Split(new char[] { ' ' });

            var smartphone = new Smartphone();

            foreach(var phone in phones)
            {
                try
                {
                    smartphone.Call(phone);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    smartphone.Browse(url);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}