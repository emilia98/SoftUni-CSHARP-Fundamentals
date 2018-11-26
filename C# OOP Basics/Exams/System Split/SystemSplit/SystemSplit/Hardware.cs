using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSplit
{
    public abstract class Hardware
    {
        public string Name {  get; set; }

        protected Hardware(string name)
        {
            this.Name = name;
        }

        public virtual void PrintName()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine(this.Name + " Peshev");
        }
    }
}
