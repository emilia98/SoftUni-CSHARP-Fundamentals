using System;

namespace _06.Animals
{
    class StartUp
    {
        static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string classType = input;
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (tokens.Length < 3)
                    {
                         throw new ArgumentException("Invalid input!");
                    }

                    string name = tokens[0];
                    int age;
                    string gender = tokens[2];

                    if(int.TryParse(tokens[1], out age) == false)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    switch(classType)
                    {
                        case "Cat":
                            {
                                var cat = new Cat(name, age, gender);
                                Console.WriteLine(cat);
                                break;
                            }
                        case "Dog":
                            {
                                var dog = new Dog(name, age, gender);
                                Console.WriteLine(dog);
                                break;
                            }
                        case "Frog":
                            {
                                var frog = new Frog(name, age, gender);
                                Console.WriteLine(frog);
                                break;
                            }
                        case "Kitten":
                            {
                                var kitten = new Kitten(name, age, "Female");
                                Console.WriteLine(kitten);
                                break;
                            }
                        case "Tomcat":
                            {
                                var tomcat = new Tomcat(name, age, "Male");
                                Console.WriteLine(tomcat);
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException("Invalid input!");
                            }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}