public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email = "n/a";
    private int age = -1;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
    }

    public string Name
    {
        get { return this.name; }
        private set { }
    }

    public decimal Salary
    {
        get { return this.salary; }
        private set { }
    }

    public string Position
    {
        get { return this.position; }
        private set { }
    }

    public string Department
    {
        get { return this.department; }
        private set { }
    }

    public string Email
    {
        get { return this.email; }
        private set { }
    }

    public int Age
    {
        get { return this.age; }
        private set { }
    }

    public Employee(string name, decimal salary, string position, string department, string email) :this(name, salary, position, department)
    {
        this.email = email;
    }

    public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
    {
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department,
                    string email, int age) : this(name, salary, position, department)
    {
        this.email = email;
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department,
                    int age, string email) : this(name, salary, position, department)
    {
        this.email = email;
        this.age = age;
    }
}

