using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FamilyTree
{
    class Program
    {
        static void Main()
        {
            var peopleByName = new Dictionary<string, Person>();
            var peopleByBirthday = new Dictionary<string, Person>();

            string firstLine = Console.ReadLine();
            var tokens = firstLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameToFind = null;
            DateTime? birthdayToFind = null;

            if (tokens.Length == 2)
            {
                string fullName = firstLine;
                nameToFind = fullName;
                var person = new Person(fullName);
                peopleByName.Add(fullName, person);
            } else if (tokens.Length == 1)
            {
                DateTime birthday;
                DateTime.TryParse(tokens[0], out birthday);
                birthdayToFind = birthday;

                var person = new Person(birthday);
                peopleByBirthday.Add(birthday.ToShortDateString(), person);
            }
            /*
            foreach (var person in peopleByBirthday)
            {
                Console.WriteLine(person.Value.Name + " => " + person.Value.Birthday);
            }

            foreach (var person in peopleByName)
            {
                Console.WriteLine(person.Value.Name + " => " + person.Value.Birthday);
            }
            */
            string input = Console.ReadLine();
            var pattern = new Regex(@"\s+\-\s+");

            while (input != "End")
            {
                tokens = pattern.Split(input);

                if (tokens.Length == 1)
                {
                    var splitedTokens = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string name = String.Concat(splitedTokens[0], " ", splitedTokens[1]);
                    DateTime? birthday = ConvertDate(splitedTokens[2]);
                    var birthdayAsString = birthday.Value.ToShortDateString();
                    Person initPerson = null;

                    if (peopleByName.ContainsKey(name))
                    {
                        peopleByName[name].Birthday = birthday;
                        initPerson = peopleByName[name];
                    }
                    else
                    {
                        initPerson = new Person(name);
                    }

                    if (peopleByBirthday.ContainsKey(birthdayAsString))
                    {
                        peopleByBirthday[birthdayAsString].Name = name;
                        // initPerson = 
                    }

                    if(initPerson == null)
                    {

                    }

                    /*
                    Console.WriteLine("HEre");
                    Console.WriteLine(birthday);
                    */
                    peopleByBirthday[birthdayAsString].Name = name;
                    peopleByName[name].Birthday = birthday;

                    var per1 = peopleByBirthday[birthdayAsString];
                    var per2 = peopleByName[name];
                    Console.WriteLine(new string('-', 25));
                    Console.WriteLine(per1.Name);
                    Console.WriteLine(per2.Name);
                    Console.WriteLine(new string('-', 25));
                    Console.WriteLine(per1.Birthday.Value);
                    Console.WriteLine(per2.Birthday.Value);
                    /*
                    Console.WriteLine(peopleByBirthday[birthdayAsString].Name + " " + peopleByBirthday[birthdayAsString].Birthday.Value.ToShortDateString());
                    Console.WriteLine(peopleByName[name].Name + " " + peopleByName[name].Birthday.Value.ToShortDateString());
                    */
                }
                else if (tokens.Length == 2)
                {
                    var firstConvert = ConvertDate(tokens[0]);
                    var secondConvert = ConvertDate(tokens[1]);

                    if (firstConvert == null)
                    {
                        string parentName = tokens[0];

                        if (peopleByName.ContainsKey(parentName) == false)
                        {
                            var person = new Person(parentName);
                            peopleByName.Add(parentName, person);
                        }

                        var parent = peopleByName[parentName];

                        if (secondConvert == null)
                        {
                            string childName = tokens[1];

                            if (peopleByName.ContainsKey(childName) == false)
                            {
                                var person = new Person(childName);
                                peopleByName.Add(childName, person);
                            }

                            var child = peopleByName[childName];
                            peopleByName[parentName].AddChild(child);
                            peopleByName[childName].AddParent(parent);
                        }
                        else
                        {
                            var childBirthday = secondConvert;
                            string birthdayToString = childBirthday.Value.ToShortDateString();

                            // Console.WriteLine(birthdayToString);
                            if (peopleByBirthday.ContainsKey(birthdayToString) == false)
                            {
                                var person = new Person(childBirthday);
                                peopleByBirthday.Add(birthdayToString, person);
                            }

                            var child = peopleByBirthday[birthdayToString];
                            
                            peopleByName[parentName].AddChild(child);
                            peopleByBirthday[birthdayToString].AddParent(parent);
                        }
                    }
                    else
                    {
                        var parentBirhday = firstConvert;
                        string birthdayToString = parentBirhday.Value.ToShortDateString();

                        if (peopleByBirthday.ContainsKey(birthdayToString) == false)
                        {
                            var person = new Person(parentBirhday);
                            peopleByBirthday.Add(birthdayToString, person);
                        }

                        var parent = peopleByBirthday[birthdayToString];

                        if (secondConvert == null)
                        {
                            string childName = tokens[1];

                            if (peopleByName.ContainsKey(childName) == false)
                            {
                                var person = new Person(childName);
                                peopleByName.Add(childName, person);
                            }

                            var child = peopleByName[childName];
                            peopleByBirthday[birthdayToString].AddChild(child);
                            peopleByName[childName].AddParent(parent);
                        }
                        else
                        {
                            var childBirthday = secondConvert;
                            string childBirthdayToString = childBirthday.Value.ToShortDateString();

                            if (peopleByBirthday.ContainsKey(childBirthdayToString) == false)
                            {
                                var person = new Person(childBirthday);
                                peopleByBirthday.Add(childBirthdayToString, person);
                            }

                            var child = peopleByBirthday[childBirthdayToString];

                            peopleByBirthday[birthdayToString].AddChild(child);
                            peopleByBirthday[childBirthdayToString].AddParent(parent);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            
            Console.WriteLine("BY BDAY: ");
            foreach (var person in peopleByBirthday)
            {
                Console.WriteLine(person.Value.Name + " => " + person.Value.Birthday);

               // Console.WriteLine(person.Value.Children.Count);
            }

            Console.WriteLine("By NAME");
            foreach (var person in peopleByName)
            {
                Console.WriteLine(person.Value.Name + " => " + person.Value.Birthday);
               // Console.WriteLine(person.Value.Children.Count);
            }
            
            
            

            Person personFound = null;

            if (nameToFind != null)
            {
                personFound = peopleByName[nameToFind];
            }

            if(birthdayToFind != null)
            {
                personFound = peopleByBirthday[birthdayToFind.Value.ToShortDateString()];
            }

            // Console.WriteLine(personFound.Name);
           // Console.WriteLine(personFound.Birthday);

            /*
             * Pesho Peshev 23/5/1980
Parents:
Stamat Peshev 11/11/1951
Penka Pesheva 9/2/1953
Children:
Gancho Peshev 1/1/2005

             * */

            var birthdayDate = personFound.Birthday.Value;
            // Console.WriteLine(birthdayToFind.Value.Date);
            Console.WriteLine($"{personFound.Name} {birthdayDate.Day}/{birthdayDate.Month}/{birthdayDate.Year}");

            Console.WriteLine("Parents:");
            foreach(var parent in personFound.Parents)
            {
                var bday = parent.Birthday.Value;
                // Console.WriteLine(birthdayToFind.Value.Date);
                Console.WriteLine($"{parent.Name} {bday.Day}/{bday.Month}/{bday.Year}");
            }

            Console.WriteLine("Children:");
            foreach (var child in personFound.Children)
            {
                var bday = child.Birthday.Value;
                // Console.WriteLine(birthdayToFind.Value.Date);
                Console.WriteLine($"{child.Name} {bday.Day}/{bday.Month}/{bday.Year}");
            }
        }

        static DateTime? ConvertDate(string str)
        {
            DateTime birthday;

            if(DateTime.TryParse(str, out birthday))
            {
                return birthday;
            }
            else
            {
                return null;
            }
        }
    }
}
