using System;

namespace Basic_Inheritance
{
    public class StartUp
    {
        static void Main()
        {
            var cat = new Cat();
            var dog = new Dog();
            var puppy = new Puppy();

            //  var animal = new Animal(); -> cannot be instantiated
            Animal.Eat();
            cat.Name = "Maca";
            cat.Move();
            dog.Age = 5;
            puppy.Age = 1;
            puppy.Pee();

            

        }
    }
}
