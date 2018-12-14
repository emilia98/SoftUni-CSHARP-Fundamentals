using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public 
                                                    | BindingFlags.Static | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach(var method in methods)
        {
            string methodName = method.Name;

            if(methodName.StartsWith("get_"))
            {
                var returnType = method.ReturnType;
                sb.AppendLine(String.Format("{0} will return {1}", methodName, returnType));
            }
        }

        foreach(var method in methods)
        {
            string methodName = method.Name;

            if(methodName.StartsWith("set_"))
            {
                var parameterType = method.GetParameters().First().ParameterType;

                sb.AppendLine(String.Format("{0} will set field of {1}", methodName, parameterType));
            }
        }

        return sb.ToString().Trim();
    }
}