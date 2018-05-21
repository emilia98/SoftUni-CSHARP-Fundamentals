using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return members.OrderByDescending(el => el.Age).First();
    }
}

