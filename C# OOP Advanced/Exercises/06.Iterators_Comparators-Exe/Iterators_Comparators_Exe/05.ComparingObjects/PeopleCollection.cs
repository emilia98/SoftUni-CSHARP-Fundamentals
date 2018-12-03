using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05.ComparingObjects
{
    public class PeopleCollection : IEnumerable<Person>
    {
        public List<Person> People { get; private set; }

        public PeopleCollection()
        {
            this.People = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            this.People.Add(person);
        }

        public Person FindPerson(int index)
        {
            return this.People[index];
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return new PeopleEnumerator(this.People);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class PeopleEnumerator : IEnumerator<Person>
        {
            private readonly List<Person> people;
            private int currentIndex;

            public PeopleEnumerator(ICollection<Person> people)
            {
                this.people = new List<Person>(people);
                this.Reset();
            }

            public Person Current => this.people[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext() => ++this.currentIndex < this.people.Count;

            public void Reset() => this.currentIndex = -1;
        }

    }
}
