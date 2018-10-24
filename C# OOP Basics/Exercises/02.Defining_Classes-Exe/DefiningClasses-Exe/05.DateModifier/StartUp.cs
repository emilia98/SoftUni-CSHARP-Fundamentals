using System;
using System.Linq;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            var firstDate = SplitDate(first);
            var secondDate = SplitDate(second);

            var dateModifier_1 = new DateModifier(firstDate[0], firstDate[1], firstDate[2]);
            var dateModifier_2 = new DateModifier(secondDate[0], secondDate[1], secondDate[2]);

            Console.WriteLine(dateModifier_1.FindDifference(dateModifier_2));
        }

        static int[] SplitDate(string date)
        {
            return date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();
        }
    }
}
