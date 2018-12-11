using System;
using System.Collections.Generic;
using System.Text;

namespace _08.PetClinic
{
    public static class CommandInterpreter
    {
        public static Pet CreatePet(params string[] tokens)
        {
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string kind = tokens[2];

            return new Pet(name, age, kind);
        }

        public static Clinic CreateClinic(params string[] tokens)
        {
            string name = tokens[0];
            int rooms = int.Parse(tokens[1]);

            return new Clinic(name, rooms);
        }

        
    }
}
