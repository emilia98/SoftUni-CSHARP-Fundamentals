using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _1
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var pattern = new Regex("s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--\"(?<message>[A-Za-z\\s]+)\"");
            int totalData = 0;

            for(int count = 1; count <= n; count++)
            {
                string line = Console.ReadLine();
                Match match = pattern.Match(line);
                var groups = match.Groups;

                if(match.Value.Length > 0)
                {
                    string sender = groups["sender"].Value;
                    string receiver = groups["receiver"].Value;
                    string message = groups["message"].Value;

                    string senderName = FilterName(sender);
                    string receiverName = FilterName(receiver);
                    int totalInSender = Calculate(sender);
                    int totalInReceiver = Calculate(receiver);

                    totalData += totalInSender + totalInReceiver;
                    Console.WriteLine($"{senderName} says \"{message}\" to {receiverName}");
                }
            }
            Console.WriteLine($"Total data transferred: {totalData}MB");
        }

        static int Calculate(string name)
        {
            var pattern = new Regex(@"[0-9]");
            MatchCollection matches = pattern.Matches(name);
            int total = 0;
            
            foreach(Match match in matches)
            {
                total += int.Parse(match.Value);
            }

            return total;
        }

        static string FilterName(string name)
        {
            var pattern = new Regex(@"[A-Za-z\s]");
            MatchCollection matches = pattern.Matches(name);
            return String.Join("", matches);
        }
    }
}