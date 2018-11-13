using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            string firstLine = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            
            while(firstLine != "End")
            {
                string secondLine = Console.ReadLine();
                
                Animal animal = GetAnimalFactory(firstLine);
                Food food = GetFoodFactory(secondLine);

                
                animal.Eat(food);
                animals.Add(animal);
                firstLine = Console.ReadLine();
            }

            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Animal GetAnimalFactory(string input)
        {
            var animalTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string animalType = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            switch(animalType)
            {
                case "Hen":
                    {
                        double wingsSize = double.Parse(animalTokens[3]);
                        return new Hen(name, weight, wingsSize);
                    }
                case "Owl":
                    {
                        double wingsSize = double.Parse(animalTokens[3]);
                        return new Owl(name, weight, wingsSize);
                    }
                case "Mouse":
                    {
                        string livingRegion = animalTokens[3];
                        return new Mouse(name, weight, livingRegion);
                    }
                case "Dog":
                    {
                        string livingRegion = animalTokens[3];
                        return new Dog(name, weight, livingRegion);
                    }
                case "Cat":
                    {
                        string livingRegion = animalTokens[3];
                        string breed = animalTokens[4];
                        return new Cat(name, weight, livingRegion, breed);
                    }
                case "Tiger":
                    {
                        string livingRegion = animalTokens[3];
                        string breed = animalTokens[4];
                        return new Tiger(name, weight, livingRegion, breed);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public static Food GetFoodFactory(string input)
        {
            var foodTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            switch(foodType)
            {
                case "Vegetable":
                    {
                        return new Vegetable(quantity);
                    }
                case "Fruit":
                    {
                        return new Fruit(quantity);
                    }
                case "Meat":
                    {
                        return new Meat(quantity);
                    }
                case "Seeds":
                    {
                        return new Seeds(quantity);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
