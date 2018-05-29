using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var departmentsInfo = new Dictionary<string, List<Employee>>();
        var salariesByDepartment = new Dictionary<string, decimal>();

        for (int index = 1; index <= n; index++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];
            string email = null;
            int? age = null;
            
            if (tokens.Length == 5)
            {
                if (int.TryParse(tokens[4], out int parsedAge))
                {
                    // If the parsing is successful, assign the value of parsedAge to age variable
                    age = parsedAge;
                }
                else
                {
                    email = tokens[4];
                }
            }
            else if (tokens.Length == 6)
            {
                email = tokens[4];
                age = int.Parse(tokens[5]);
            }

            var employee = new Employee(name, salary, position, department, email, age);

            if (!departmentsInfo.ContainsKey(department))
            {
                departmentsInfo.Add(department, new List<Employee>());
                salariesByDepartment.Add(department, 0);
            }

            var employeesCount = departmentsInfo[department].Count;
            var oldAverage = salariesByDepartment[department];

            departmentsInfo[department].Add(employee);
            salariesByDepartment[department] += salary;
        }

        salariesByDepartment.ToDictionary(k => k.Key, k => k.Value / departmentsInfo[k.Key].Count);
    
        string bestDepartment = salariesByDepartment
            .OrderByDescending(d => d.Value)
            .Take(1)
            .ToList()[0].Key;
        
        var departmentEmployees = departmentsInfo[bestDepartment];
        var employeesBySalary = departmentEmployees.OrderByDescending(el => el.salary);

        Console.WriteLine($"Highest Average Salary: {bestDepartment}");
        foreach (var employee in employeesBySalary)
        {
            Console.WriteLine("{0} {1:f2} {2} {3}",
                employee.name, employee.salary, employee.email, employee.age);
        }
    }
}