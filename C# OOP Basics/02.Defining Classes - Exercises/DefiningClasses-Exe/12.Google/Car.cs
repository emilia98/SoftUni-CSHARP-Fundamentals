using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.model, this.speed);
    }
}

