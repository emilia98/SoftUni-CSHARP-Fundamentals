public class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email = "n/a";
    public int? age = -1;

    public Employee(string name, decimal salary, string position,
                    string department, string email, int? age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;

        if(email != null)
        {
            this.email = email;
        }

        if(age != null)
        {
            this.age = age;
        }
    }
}

