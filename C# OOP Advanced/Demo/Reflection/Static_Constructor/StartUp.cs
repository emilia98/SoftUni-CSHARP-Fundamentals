using System;

namespace Static_Constructor
{
    public class StartUp
    {
        static void Main()
        {
            var constructors = typeof(Cat).GetConstructors();

            foreach(var constructor in constructors)
            {
                var parameters = constructor.GetParameters();

                foreach(var parameter in parameters)
                {
                    Console.WriteLine($"{parameter.Name} ({parameter.ParameterType})");
                }

                Console.WriteLine("--------------------");
            }

            var ctor = typeof(Dog).GetConstructor(Type.EmptyTypes);
            var parametersCount = ctor.GetParameters();

            Console.WriteLine(parametersCount);


        }
    }
}
