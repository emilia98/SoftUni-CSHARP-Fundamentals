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
            string email;
            int age;

            Employee employee;
            if (tokens.Length == 5)
            {
                if (int.TryParse(tokens[4], out age))
                {
                    employee = new Employee(name, salary, position, department, age);
                }
                else
                {
                    email = tokens[4];
                    employee = new Employee(name, salary, position, department, email);
                }
            }
            else if (tokens.Length == 6)
            {
                email = tokens[4];
                age = int.Parse(tokens[5]);
                employee = new Employee(name, salary, position, department, email, age);
            }
            else
            {
                employee = new Employee(name, salary, position, department);
            }


            if (!departmentsInfo.ContainsKey(department))
            {
                departmentsInfo.Add(department, new List<Employee>());
                salariesByDepartment.Add(department, 0);
            }

            departmentsInfo[department].Add(employee);
            var oldAverage = salariesByDepartment[department];
            salariesByDepartment[department] += salary;
        }

        var allDepartments = salariesByDepartment.Keys.ToList();

        foreach (var department in allDepartments)
        {
            decimal totalSalaries = salariesByDepartment[department];
            int totalEmployees = departmentsInfo.Values.Count();
            salariesByDepartment[department] = totalSalaries / totalEmployees;
        }

        var highestAverageDepartment = salariesByDepartment
                            .OrderByDescending(d => d.Value)
                            .Take(1)
                            .ToList();
        var bestDepartment = highestAverageDepartment[0].Key;

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

