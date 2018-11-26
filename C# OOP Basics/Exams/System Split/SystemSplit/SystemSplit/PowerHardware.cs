using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSplit
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name) : base(name)
        {
            this.Name = "Pesho";
        }

        // public new string Name { get;  set; }

        /*public override void PrintName()
        {
            // base.PrintName();
            Console.WriteLine(this.Name + " Peshev");
        }*/
    }
}
