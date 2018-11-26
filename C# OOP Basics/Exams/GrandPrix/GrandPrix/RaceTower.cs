using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace GrandPrix
//{
public class RaceTower
{
    public static Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
    public static Dictionary<string, Driver> failedDrivers = new Dictionary<string, Driver>();
    //public static int laps = 0;
    // public static int trackLength = 0;
    public static int lapsCompleted = 0;
    public static Track track = null;

    static void Main()
    {
        int laps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        SetTrackInfo(laps, trackLength);

        while (lapsCompleted < laps)
        {
            string command = Console.ReadLine();
            var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            // var tokens = command.Split();
            string commandType = tokens[0];
            var commandArgs = tokens.Skip(1).ToList();

            if (commandType == "RegisterDriver")
            {
                RegisterDriver(commandArgs);

                /* foreach (var driver in drivers)
                 {
                     Console.WriteLine(driver.Key);
                     Console.WriteLine(driver.Value.Speed);
                 }*/
            }
            else if (commandType == "CompleteLaps")
            {
                int lapsToComplete = int.Parse(commandArgs[0]);

                //CompleteLaps(lapsToComplete);
                
                try
                {
CompleteLaps(lapsToComplete);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            else if(commandType == "Box")
            {
                DriverBoxes(commandArgs);
               
            }
            else if(commandType == "Leaderboard")
            {
                Console.Write(GetLeaderboard());
            }
            else if(commandType == "ChangeWeather")
            {
                string weather = tokens[1];

                ChangeWeather(weather);
            }
        }

        /*
        foreach(var driver in drivers.Values)
        {
            Console.WriteLine($"{driver.Name} -> {driver.TotalTime}");
        }
        */

        drivers = drivers.OrderBy(x => x.Value.TotalTime).ToDictionary(x => x.Key, x => x.Value);
        var winner = drivers.Values.ToList()[0];
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
    }

    public static void SetTrackInfo(int lapsNumber, int trackLength)
    {
        track = new Track(lapsNumber, trackLength);
    }

    public static void RegisterDriver(List<string> commandArgs)
    {
        if (commandArgs.Count < 6 && commandArgs.Count > 7)
        {
            return;
        }

        string driverType = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);

        Tyre tyre = null;
        Car car = null;
        Driver driver = null;

        if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(commandArgs[6]);

           

           // tyre = new UltrasoftTyre(tyreHardness, grip);
            
            try
            {
                tyre = new UltrasoftTyre(tyreHardness, grip);
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return;
            }
        }
        else if (tyreType == "Hard")
        {
           // tyre = new HardTyre(tyreHardness);
            
            try
            {
                tyre = new HardTyre(tyreHardness);
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return;
            }
            
        }
        else
        {
            return;
        }

       // car = new Car(hp, fuelAmount, tyre);
        
        try
        {
            car = new Car(hp, fuelAmount, tyre);
        }
        catch (Exception ex)
        {
            // Console.WriteLine(ex.Message);
            return;
        }
        

        if (driverType == "Aggressive")
        {
           // driver = new AggressiveDriver(name, car);
            
            try
            {
                driver = new AggressiveDriver(name, car);
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return;
            }
            
        }
        else if (driverType == "Endurance")
        {
            // driver = new EnduranceDriver(name, car);
            
            try
            {
                driver = new EnduranceDriver(name, car);
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return;
            }
            
        }
        else
        {
            return;
        }

        drivers.Add(name, driver);
    }

    public static void DriverBoxes(List<string> commandArgs)
    {
        string boxingType = commandArgs[0];
        string driverName = commandArgs[1];
        Driver driver = null;

        if (drivers.ContainsKey(driverName) == false)
        {
            return;
        }

        driver = drivers[driverName];

        if (boxingType == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);
            
            try
            {
                driver.Car.Refuel(fuelAmount);
                driver.VisitBox();
            }
            catch (Exception ex)
            {
                string failureType = ex.Message;
                FailDriver(driver.Name, failureType);
            }
            
        }
        else if (boxingType == "ChangeTyres")
        {
            string tyreType = commandArgs[2];
            double hardness = double.Parse(commandArgs[3]);
            Tyre tyre = null;

            switch(tyreType)
            {
                case "Ultrasoft":
                    {
                        double grip = double.Parse(commandArgs[4]);
                        
                        try
                        {
                            tyre = new UltrasoftTyre(hardness, grip);
                            driver.Car.ChangeTyres(tyre);
                            driver.VisitBox();
                           // driver.IncreaseTotalTime()
                        }
                        catch(Exception ex)
                        {
                            string failureType = ex.Message;
                            FailDriver(driver.Name, failureType);
                        }
                        break;
                    }
                case "Hard":
                    {
                        
                        
                        try
                        {
                            tyre = new HardTyre(hardness);
                            driver.Car.ChangeTyres(tyre);
                            driver.VisitBox();
                        }
                        catch (Exception ex)
                        {
                            string failureType = ex.Message;
                            FailDriver(driver.Name, failureType);
                        }
                        
                        break;
                    }
            }


        }
    }

    public static string CompleteLaps(int lapsToComplete)
    {
        if (lapsToComplete + lapsCompleted > track.Laps)
        {
            throw new Exception(String.Format($"There is no time! On lap {lapsCompleted}."));
        }

        lapsCompleted += lapsToComplete;
        
        for (int lap = 1; lap <= lapsToComplete; lap++)
        {
            // Console.WriteLine(lap);
            var driversToLoop = drivers.Values.ToList();

            for(int index = 0; index < driversToLoop.Count; index++)
            {
                Driver driver = driversToLoop[index];

                try
                {
                    driver.IncreaseTotalTime(track.Length);
                    driver.Car.ReduceFuel(track.Length, driver);
                    driver.Car.Tyre.DecreaseDegradation();
                }
                catch (Exception ex)
                {
                    string failureType = ex.Message;
                    string driverName = driver.Name;

                    
                    FailDriver(driverName, failureType);
                    driversToLoop.RemoveAt(index);
                    index--;
                }
            }
            /*
            foreach (var driver in drivers.Values)
            {
                try
                {
                    driver.IncreaseTotalTime(track.Length);
                    driver.Car.ReduceFuel(track.Length, driver);
                    driver.Car.Tyre.DecreaseDegradation();
                }
                catch (Exception ex)
                {
                    string failureType = ex.Message;
                    string driverName = driver.Name;

                    FailDriver(driverName, failureType);
                }
            }*/

            var sortedDrivers = drivers.OrderByDescending(x => x.Value.TotalTime).ToDictionary(x => x.Key, x => x.Value);
            var names = sortedDrivers.Keys.ToList();
            int lastIndex = names.Count - 2;
            var overtaken = new List<string>();

            for (int index = 0; index <= names.Count - 2; index++)
            {
                string currentDriverName = names[index];
                string nextDriverName = names[index + 1];

                Driver current = drivers[currentDriverName];
                Driver next = drivers[nextDriverName];

                string driverType = current.GetType().Name;
                string tyreType = current.Car.Tyre.GetType().Name;

                string failureType = null;
                
                if (driverType == "AggressiveDriver" && tyreType == "UltrasoftTyre")
                {
                    if (track.Weather == "Foggy")
                    {
                        failureType = "Crashed";
                        FailDriver(currentDriverName, failureType);
                        
                        names.RemoveAt(index);
                       // index--;
                        //lastIndex--;
                        //drivers[currentDriverName].SetFailure();
                    }

                    else if(current.TotalTime - next.TotalTime <= 3)
                    {
                        Overtake(current, next, 3, 3);

                        Console.WriteLine($"{currentDriverName} has overtaken {nextDriverName} on lap {lap}.");

                        // names[index] = nextDriverName;
                        // names[index + 1] = currentDriverName;
                        index++;
                    }
                }
                else if (driverType == "EnduranceDriver" && tyreType == "HardTyre")
                {
                    if (track.Weather == "Rainy")
                    {
                        failureType = "Crashed";
                        FailDriver(currentDriverName, failureType);

                        names.RemoveAt(index);
                       //  index--;
                        // lastIndex--;
                        // drivers[currentDriverName].SetFailure("Crashed");
                    }

                    else if (current.TotalTime - next.TotalTime <= 3)
                    {
                        Overtake(current, next, 3, 3);
                        
                        Console.WriteLine($"{currentDriverName} has overtaken {nextDriverName} on lap {lap}.");
                       // names[index] = nextDriverName;
                        // names[index + 1] = currentDriverName;
                        index++;
                    }
                }
                else
                {
                    if (current.TotalTime - next.TotalTime <= 2)
                    {
                        Overtake(current, next, 2, 2);

                        Console.WriteLine($"{currentDriverName} has overtaken {nextDriverName} on lap {lap}.");
                        // names[index] = nextDriverName;
                        //names[index + 1] = currentDriverName;
                         index++;
                    }
                }
            }

           // drivers = drivers.OrderBy(x => x.Value.TotalTime).ToDictionary(x => x.Key, x => x.Value);


            // for(int index = 0; index < sor)


        }
        
        return "";
    }

    public static void FailDriver(string driverName, string failureType)
    {
        //Console.WriteLine(driverName);
        Driver failedDriver = drivers[driverName];
        // Remove the driver from drivers list
        drivers.Remove(driverName);
        // Add the driver in the failed list
        failedDrivers.Add(driverName, failedDriver);
        // Set the failure of the driver
        
        failedDriver.SetFailure(failureType);
    }

    public static void Overtake(Driver current, Driver next, int secondsToDecrease, int secsondsToIncrease)
    {
        current.Overtake(secondsToDecrease);
        next.BeOvertaken(secsondsToIncrease);
    }

    public static string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {lapsCompleted}/{track.Laps}");
        
        int position = 1;

       // drivers = drivers.OrderBy(x => x.Value.TotalTime).ToDictionary(x => x.Key, x => x.Value);
        var sortedDrivers = drivers.Values.OrderBy(x => x.TotalTime).ToList();

        foreach(var driver in sortedDrivers)
        {/*
            string result = "";

            if(driver.Failure == null)
            {
                result = String.Format("{0:f3}", driver.TotalTime);
            }
            else
            {
                result = driver.Failure.Type;
            }
            */
            sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
            position++;
        }

        /*
        foreach(var driver in failedDrivers.Values.OrderByDescending(x => x.TotalTime))
        {
            sb.AppendLine($"{position} {driver.Name} {driver.Failure.Type}");
            position++;
        }*/
        // var here = failedDrivers.Values.ToList();
        // here.Reverse();
        // var here = failedDrivers.Values.Reverse();

        
        var here = failedDrivers.Values.ToList();
        for (int index = here.Count - 1; index >= 0; index--)
        {
            var driver = here[index];
            sb.AppendLine($"{position} {driver.Name} {driver.Failure.Type}");
            position++;
        }
        return sb.ToString();
    }

    public static void ChangeWeather(string weather)
    {
        track.ChangeWeather(weather);
    }
}
//}
