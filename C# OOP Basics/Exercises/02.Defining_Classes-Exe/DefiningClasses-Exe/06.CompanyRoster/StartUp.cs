using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        static void Main()
        {
            var departmentsData = new Dictionary<string, List<Employee>>();
            int linesCount = int.Parse(Console.ReadLine());

            for (int cnt = 1; cnt <= linesCount; cnt++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal salary = decimal.Parse(tokens[1]);
                string position = tokens[2];
                string department = tokens[3];

                Employee employee = null;

                if(tokens.Length == 4)
                {
                    employee = new Employee(name, salary, position, department);
                }
                else if(tokens.Length == 6)
                {
                    string email = tokens[4];
                    int age = int.Parse(tokens[5]);
                    employee = new Employee(name, salary, position, department, email, age);
                }
                else if(tokens.Length == 5)
                {
                    int lastToken;
                    bool isInt = Int32.TryParse(tokens[4], out lastToken);

                    if (isInt)
                    {
                        int age = lastToken;
                        employee = new Employee(name, salary, position, department, age);
                    }
                    else
                    {
                        string email = tokens[4];
                        employee = new Employee(name, salary, position, department, email);
                    }
                }
                
                if(departmentsData.ContainsKey(department) == false)
                {
                    departmentsData.Add(department, new List<Employee>());
                }
                
                if(employee != null)
                {
                    departmentsData[department].Add(employee);
                }
            }

            var sortedDepartments = departmentsData.OrderByDescending(x => x.Value.Sum(y => y.Salary) / x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach(var departmentInfo in sortedDepartments)
            {
                string department = departmentInfo.Key;
                var employees = departmentInfo.Value;

                Console.WriteLine($"Highest Average Salary: {department}");

                foreach(var employee in employees.OrderByDescending(x => x.Salary))
                {
                    Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
                }

                break;
            }
        }
    }
}