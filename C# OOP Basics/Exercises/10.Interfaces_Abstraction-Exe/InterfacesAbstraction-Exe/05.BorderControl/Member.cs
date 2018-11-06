using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    public class Member : IMember
    {
        public virtual string Id { get; protected set; }

        public bool ShouldBeDetained(string fakeId)
        {
            return this.Id.EndsWith(fakeId);
        }
    }
}