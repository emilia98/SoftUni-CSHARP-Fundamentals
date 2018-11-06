using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public interface IMember
    {
        string Id { get; }

        bool ShouldBeDetained(string fakeId);
    }
}
