using System;

namespace Generic_Class
{
    public class StartUp
    {
        public static void Main()
        {
            var data = new MyCustomData<int>();

            data.Add(1);
            data.Add(2);
            data.Add(15);

            var textData = new MyCustomData<string>();

            textData.Add("Hello");
            textData.Add("Pesho");

            Console.WriteLine(data.Count);
            Console.WriteLine(textData.Count);

            var result = textData[0];
            Console.WriteLine(result);
            Console.WriteLine(data[2]);

            textData[1] = "World";
            Console.WriteLine(textData[1]);
        }
    }
}