using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Robot : Member
    {
        public string Model { get; private set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
