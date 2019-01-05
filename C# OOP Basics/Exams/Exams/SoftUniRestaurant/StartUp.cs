using AnimalCentre.Core;
using SoftUniRestaurant.IO;
using System;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
