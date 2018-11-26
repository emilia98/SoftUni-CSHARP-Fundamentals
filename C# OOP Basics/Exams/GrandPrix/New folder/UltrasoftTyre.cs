using System;
using System.Collections.Generic;
using System.Text;


    public class UltrasoftTyre : Tyre
    {
        private static string Name = "Ultrasoft";

        private double grip;

        //TODO: Validations: Grip is a positive number
        public double Grip
        {
            get { return this.grip; }
            set
            {
                this.grip = value;
            }
        }

        public override double Degradation
        {
            get { return this.degradation; }
            protected set
            {
                if(value < 30)
                {
                    throw new ArgumentException("Blown Tyre");
                }
                
                this.degradation = value;
            }
        }

        public UltrasoftTyre(double hardness, double grip) : base(UltrasoftTyre.Name, hardness)
        {
            this.Grip = grip;
        }
    }
