using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree
{
    class Person
    {
        private string name;
        private DateTime? birthday;
        private List<Person> parents;
        private List<Person> children;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime? Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public List<Person> Parents
        {
            get {  return this.parents; }
        }

        public List<Person> Children
        {
            get { return this.children; }
        }

        public Person()
        {
            this.name = null;
            this.birthday = null;
            this.parents = new List<Person>();
            this.children = new List<Person>();
        }

        public Person(string name) :this()
        {
            this.name = name;
        }

        public Person(DateTime? birthday) :this()
        {
            this.birthday = birthday;
        }

        public void AddParent(Person parent)
        {
            this.parents.Add(parent);
        }

        public void AddChild(Person child)
        {
            this.children.Add(child);
        }
    }
}
