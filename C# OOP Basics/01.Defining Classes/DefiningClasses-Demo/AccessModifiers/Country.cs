using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Country
    {
        private class Town
        {
            string townName;
            int population;

            public string TownName
            {
                get { return this.townName; }
                set { this.townName = value; }
            }

            void Say()
            {
                Console.WriteLine("Don't be offended!");
                if(this.townName == "Sofia")
                {
                    Console.WriteLine("Ohoo, korenyak!");
                }
                else
                {
                    Console.WriteLine("Provinciya? Hah, provinciyalist!");
                }
            }

            public void Test()
            {
                Say();
            }
        }

        string name;

        public string Name
        {
            get; private set;
        }


        public void Initialize(string countryName)
        {
            /* We have an access to the settery, 
               so we could set a value, when we call this method
            */
            this.Name = countryName;
            this.SaySomething();
        }

        void SaySomething()
        {
            Console.WriteLine("Ebasi rabotata! Tez sa oligofreni, mamka mu!");
        }

        public void NewTown()
        {
            var town1 = new Town();
            town1.TownName = "Sofia";
           
            // town1.Say(); // No Access;
            town1.Test();

            var town2 = new Town();
            town2.TownName = "Gabrovo";
            town2.Test();
            // town2.population = 50000; -> No Access
            // Console.WriteLine(town2.population); -> No Access
        }
    }
}
