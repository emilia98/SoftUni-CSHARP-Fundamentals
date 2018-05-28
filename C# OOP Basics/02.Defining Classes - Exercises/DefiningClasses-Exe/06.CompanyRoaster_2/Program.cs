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
            string[] tokens = input.Split(' ');

            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];
            string email = "n/a";
            int age = -1;

            var employee = new Employee();
            
            employee.Name = name;
            employee.Salary = salary;
            employee.Position = position;
            employee.Department = department;
            employee.Email = email;
            employee.Age = age;
            
            if (tokens.Length == 5)
            {
                if (int.TryParse(tokens[4], out age))
                {
                    employee.Age = age;
                }
                else
                {
                    email = tokens[4];
                    employee.Email = email;
                }
            }
            else if (tokens.Length == 6)
            {
                email = tokens[4];
                age = int.Parse(tokens[5]);
                employee.Email = email;
                employee.Age = age;
            }

            if (!departmentsInfo.ContainsKey(department))
            {
                departmentsInfo.Add(department, new List<Employee>());
                salariesByDepartment.Add(department, 0);
            }

            departmentsInfo[department].Add(employee);
            salariesByDepartment[department] += salary;
        }

        var allDepartments = salariesByDepartment.Keys.ToList();
        decimal maxAverage = decimal.MinValue;
        string bestDepartment = "";

        
        foreach (var department in allDepartments)
        {
            decimal totalSalaries = salariesByDepartment[department];
            int totalEmployees = departmentsInfo.Values.Count();
            decimal average = totalSalaries / totalEmployees;

            if(maxAverage < average)
            {
                bestDepartment = department;
                maxAverage = average;
            }
        }

        var departmentEmployees = departmentsInfo[bestDepartment];
        var employeesBySalary = departmentEmployees.OrderByDescending(el => el.Salary);

        Console.WriteLine($"Highest Average Salary: {bestDepartment}");
        foreach (var employee in employeesBySalary)
        {
            Console.WriteLine("{0} {1:f2} {2} {3}",
                employee.Name, employee.Salary, employee.Email, employee.Age);
        }
    }
}