using System;
using System.Collections.Generic;
using System.Text;

//namespace Avatar
//{
    public abstract class Monument : IMonument
    {
        public string Name { get; }

        protected Monument(string name)
        {
            this.Name = name;
        }
    }
//}