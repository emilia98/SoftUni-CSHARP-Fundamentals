using System;

namespace NameCollision
{
    class Transaction
    {
        int id;

        public int ID
        {
            get; private set;
        }

        public void Initilize(int id, decimal price)
        {
            // The local variable (the variable with name id, initilized in the method)
            // has a priority
            id = id;
            Console.WriteLine("Instance id = " + this.id);
            Console.WriteLine("The id of the method = " + id);
        }

        public void InitilizeFixed(int id, decimal price)
        {
            // The local variable (the variable with name id, initilized in the method)
            // has a priority
            ID = id;
            Console.WriteLine("Instance id = " + ID);
            Console.WriteLine("The id of the method = " + id);
        }
    }
}
