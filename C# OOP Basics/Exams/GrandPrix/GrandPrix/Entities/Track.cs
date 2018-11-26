using System;
using System.Collections.Generic;
using System.Text;

//namespace GrandPrix
//
public class Track
{
    public string Weather { get; private set; }

    public int Laps { get; }

    public int Length { get; }

    public Track(int laps, int trackLength)
    {
        this.Weather = "Sunny";
        this.Laps = laps;
        this.Length = trackLength;
    }

    public void ChangeWeather(string weather)
    {
        this.Weather = weather;
    }
}
//}