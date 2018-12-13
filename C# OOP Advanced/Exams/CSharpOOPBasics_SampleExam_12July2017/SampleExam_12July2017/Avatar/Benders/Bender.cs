using System;
using System.Collections.Generic;
using System.Text;


//namespace Avatar
// {
    public abstract class Bender : IBender
    {
        // SHOULD HAVE SETTER
        public string Name { get; }

        // SHOULD HAVE SETTER
        public int Power { get; }

        protected Bender(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
    }
//}
