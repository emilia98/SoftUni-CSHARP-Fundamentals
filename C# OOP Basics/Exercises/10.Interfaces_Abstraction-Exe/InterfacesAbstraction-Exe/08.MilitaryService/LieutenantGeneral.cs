using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryService
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; private set; }

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }
    }
}