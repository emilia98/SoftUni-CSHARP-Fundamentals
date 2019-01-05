using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.IO
{
    public interface IWriter
    {
        void WriteLine(string message);
        void Flush();
    }
}
