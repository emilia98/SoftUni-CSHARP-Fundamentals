using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class StartUp
    {
        static Dictionary<string, Person> peopleData;
        static Dictionary<string, Product> productsData;

        static void Main()
        {
            var peopleDataTokens = Console.ReadLine()
                                      .Split(new char[] { ';' },
                                             StringSplitOptions.RemoveEmptyEntries);
            var productsDataTokens = Console.ReadLine()
                                        .Split(new char[] { ';' },
                                               StringSplitOptions.RemoveEmptyEntries);

            peopleData = new Dictionary<string, Person>();
            productsData = new Dictionary<string, Product>();

            AddPeopleData(peopleDataTokens);
            AddProductsData(productsDataTokens);

            var input = Console.ReadLine();
             
            while(input != "END")
            {
                var tokens = input.Split(new char[] { ' ' },
                                         StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                if(peopleData.ContainsKey(personName) && productsData.ContainsKey(productName))
                {
                    var person = peopleData[personName];
                    var product = productsData[productName];

                    person.AddProductToBag(product);
                }
                input = Console.ReadLine();
            }

            var people = peopleData.Values.ToList();

            foreach(var person in people)
            {
                var products = person.Bag.ToList();

                if(products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }
                
                Console.WriteLine($"{person.Name} - {String.Join(", ", products.Select(x => x.Name))}");
            }
        }

        static void AddPeopleData(string[] peopleDataTokens)
        {
            foreach (var personToken in peopleDataTokens)
            {
                var tokens = personToken.Split(new char[] { '=' });// StringSplitOptions.RemoveEmptyEntries);
                // Console.WriteLine(String.Join(" => ", tokens));
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                Person person = null;

                try
                {
                    person = new Person(name, money);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    // throw new Exception("S");
                    return;
                }

                if (peopleData.ContainsKey(name) == false)
                {
                    peopleData.Add(name, null);
                }
                peopleData[name] = person;
            }
        }

        static void AddProductsData(string[] productsDataTokens)
        {
            foreach (var productToken in productsDataTokens)
            {
                var tokens = productToken.Split(new char[] { '='}); // StringSplitOptions.RemoveEmptyEntries);
                // Console.WriteLine(String.Join(" => ", tokens));
                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                Product product = null;

                try
                {
                    product = new Product(name, cost);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    // throw new Exception("S");
                    return;
                }

                if (productsData.ContainsKey(name) == false)
                {
                    productsData.Add(name, null);
                }
                productsData[name] = product;
            }
        }
    }
}