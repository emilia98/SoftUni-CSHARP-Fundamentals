using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            var scale = new Scale<int>(7, 6);
            Console.WriteLine(scale.GetHeavier());
        }
    }
}