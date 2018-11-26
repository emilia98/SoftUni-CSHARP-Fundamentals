using System;
using System.Collections.Generic;
using System.Text;


    public class HardTyre : Tyre
    {
        private static string Name = "Hard";

        public HardTyre(double hardness) : base(HardTyre.Name, hardness)
        {
        }
    }
