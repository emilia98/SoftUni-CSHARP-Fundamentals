using System;

namespace SoftUniRestaurant.IO
{
    public class Reader : IReader

    {
    public string readData()
    {
        return Console.ReadLine();
    }
    }
}