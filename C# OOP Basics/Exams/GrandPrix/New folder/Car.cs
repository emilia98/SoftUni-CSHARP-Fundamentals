using System;
using System.Collections.Generic;
using System.Text;


    public class Car
    {
        //TODO: Private setters
        //TODO: Constructor
        private int hp;
        private double fuelAmount;
        private Tyre tyre;

        public int Hp
        {
            get { return this.hp; }
            set { this.hp = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Out of fuel");
                }

                if(value >= 160)
                {
                    this.fuelAmount = 160;
                }
                else
                {
                    this.fuelAmount = value;
                }
            }
        }

        public Tyre Tyre
        {
            get { return this.tyre; }
            set
            {
                this.tyre = value;
            }
        }

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            this.Hp = hp;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }
    }
