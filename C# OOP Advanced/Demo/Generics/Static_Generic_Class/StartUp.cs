using System;

namespace Static_Generic_Class
{
    public class StartUp
    {
        static void Main()
        {
            SomeStaticClass<int>.Value = 5;
            SomeStaticClass<double>.Value = 4.68;
            SomeStaticClass<string>.Value = "Some Text";

            var result = SomeStaticClass<int>.Value;
            var result2 = SomeStaticClass<double>.Value;
            var result3 = SomeStaticClass<string>.Value;

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }
    }
}
