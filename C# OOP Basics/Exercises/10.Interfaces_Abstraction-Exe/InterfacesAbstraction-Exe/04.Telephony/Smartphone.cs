using System;
using System.Text.RegularExpressions;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public void Browse(string url)
        {
            if(Regex.IsMatch(url, @"[0-9]+"))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            if(Regex.IsMatch(number, @"^([0-9]+)$") == false)
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}