using System;

namespace Route_Value_Dictionary
{
    public class StartUp
    {
        static void Main()
        {
            var dict = new RouteValueDictionary();
            
            dict.Add("Func", new object());
            dict.NewFunc();
        }
    }
}