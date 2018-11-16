using System;
using System.Collections.Generic;
using System.Text;

namespace Route_Value_Dictionary
{
    public class RouteValueDictionary : Dictionary<string, object>
    {
        public void NewFunc()
        {
            if(this.ContainsKey("Func"))
            {
                Console.WriteLine("FUNC");
            }
        }
    }
}
