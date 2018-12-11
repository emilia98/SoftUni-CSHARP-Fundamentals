using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.PetClinic
{
    class Program
    {
        public static List<Pet> pets;
        public static List<Clinic> clinics;

        static void Main()
        {
            pets = new List<Pet>();
            clinics = new List<Clinic>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int cnt = 1; cnt <= linesCount; cnt++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(" ");

                Interpretate(tokens);
            }
        }

        public static void Interpretate(string[] tokens)
        {
            string commandType = tokens[0];

            switch (commandType)
            {
                case "Create":
                    {
                        string typeOfCreation = tokens[1];

                        if (typeOfCreation == "Pet")
                        {
                            var pet = CommandInterpreter.CreatePet(tokens.Skip(2).ToArray());
                            pets.Add(pet);
                        }
                        else if (typeOfCreation == "Clinic")
                        {
                            try
                            {
                                var clinic = CommandInterpreter.CreateClinic(tokens.Skip(2).ToArray());
                                clinics.Add(clinic);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine("Invalid Operation!");
                            }

                        }
                        return;
                    }
                case "Add":
                    {
                        string petName = tokens[1];
                        string clinicName = tokens[2];

                        Pet pet = FindPet(petName);
                        Clinic clinic = FindClinic(clinicName);

                        if(pet != null && clinic != null)
                        {
                            Console.WriteLine(clinic.AddNewPet(pet));
                        }
                        return;
                    }
            }
        }

        public static Pet FindPet(string petName)
        {
            foreach(var pet in pets)
            {
                if(pet.Name == petName)
                {
                    return pet;
                }
            }

            return null; 
        }

        public static Clinic FindClinic(string clinicName)
        {
            foreach(var clinic in clinics)
            {
                if(clinic.Name == clinicName)
                {
                    return clinic;
                }
            }

            return null;
        }
    }
}
