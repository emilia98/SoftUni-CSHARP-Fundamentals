using System;
using System.Collections.Generic;
using System.Text;

//namespace GrandPrix
//{
public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    public string Name
    {
        get { return this.name; }
        private set
        {
            this.name = value;
        }
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public double Hardness
    {
        get { return this.hardness; }
        private set
        {
            this.hardness = value;
        }
    }

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual void DecreaseDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}
//}
