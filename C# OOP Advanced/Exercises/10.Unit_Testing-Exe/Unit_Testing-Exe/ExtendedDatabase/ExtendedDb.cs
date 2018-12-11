using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedDatabase
{
    public class ExtendedDb
    {
        private static int elementsCount = 16;
        private int currentIndex = -1;
        private Person[] storage;

        public int Elements
        {
            get { return this.currentIndex + 1; }
        }

        public Person[] Storage
        {
            get { return this.storage; }
        }

        public ExtendedDb()
        {
            this.storage = new Person[elementsCount];

            /*
            foreach (var person in people)
            {
                if (this.Elements > 15)
                {
                    throw new InvalidOperationException("Init array will exceed the max capacity of the array!");
                }
                this.storage[++currentIndex] = person;
            }*/
        }

        public void Add(Person person)
        {
            if (currentIndex == 15)
            {
                throw new InvalidOperationException("You exceeded the max capacity of the array");
            }

            if (person == null)
            {
                return;
            }

            foreach (var p in this.storage)
            {
                if (p == null)
                {
                    continue;
                }

                if (person.Id == p.Id)
                {
                    throw new InvalidOperationException("Duplicate Ids");
                }

                if (person.Username == p.Username)
                {
                    throw new InvalidOperationException("Duplicate Usernames");
                }
            }
            this.storage[++currentIndex] = person;
        }

        public void Remove()
        {
            if (currentIndex == -1)
            {
                throw new InvalidOperationException("Cannot remove an element from empty collection!");
            }

            this.storage[currentIndex] = null;
            --currentIndex;
        }

        public Person[] Fetch()
        {
            return this.Storage.Where(x => x != null).ToArray();
        }

        public Person FindById(long id)
        {
            if(id < 0)
            {
                throw new ArgumentOutOfRangeException("Negative id found!");
            }

            foreach(var person in this.storage)
            {
                if(person != null && person.Id == id)
                {
                    return person;
                }
            }

            throw new InvalidOperationException("No user with this id is present!");
        }

        public Person FindByUsername(string username)
        {
            if(username == null)
            {
                throw new ArgumentNullException("Username should not be null!");
            }

            foreach (var person in this.storage)
            {
                if (person != null && person.Username == username)
                {
                    return person;
                }
            }

            throw new InvalidOperationException("No user with this username is present!");
        }
    }
}
