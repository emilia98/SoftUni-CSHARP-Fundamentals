using System;
using System.Collections.Generic;
using System.Text;

namespace Static_Generic_Class
{
    public static class SomeStaticClass<T>
    {
        private static T savedValue;

        public static T Value
        {
            get
            {
                return savedValue;
            }
            set
            {
                savedValue = value;
            }
        }
    }
}
