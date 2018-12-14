using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        string baseClassName = classType.BaseType.Name;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine(String.Format("All Private Methods of Class: {0}", className));
        sb.AppendLine(String.Format("Base Class: {0}", baseClassName));

        foreach(var method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}