using System.Collections.Generic;

class Family
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        int max = int.MinValue;
        Person oldestPerson = null;
        foreach (var member in this.members)
        {
            if (member.Age > max)
            {
                max = member.Age;
                oldestPerson = member;
            }
        }
        return oldestPerson;
    }
}

