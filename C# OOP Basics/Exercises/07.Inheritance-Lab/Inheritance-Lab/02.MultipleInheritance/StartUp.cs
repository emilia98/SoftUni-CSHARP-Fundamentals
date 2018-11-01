namespace Farm
{
    public class StartUp
    {
        static void Main()
        {
            var dog = new Dog();
            dog.Eat();
            dog.Bark();

            var puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}