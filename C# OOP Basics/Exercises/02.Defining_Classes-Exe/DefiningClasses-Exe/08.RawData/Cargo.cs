using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Cargo
    {
        private string type;
        private int weight;

        public Cargo(string type,int weight)
        {
            this.type = type;
            this.weight = weight;
        }

        public string Type
        {
            get { return this.type; }
        }

        public int Weight
        {
            get { return this.weight; }
        }
    }
}
