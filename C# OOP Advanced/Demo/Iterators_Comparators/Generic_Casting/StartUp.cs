using System.Collections.Generic;

namespace Generic_Casting
{
    public class StartUp
    {
        static void Main()
        {
            //
            IEnumerable<int> someNums = new List<int>();
            ICollection<int> collection = (ICollection<int>)someNums;

            // Does not work, because out T is an obejct, but not int
            IEnumerable<object> someVats = new List<int>();
        }
    }
}