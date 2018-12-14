using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                         BindingFlags.NonPublic | BindingFlags.Public);
        var methods = classType.GetMethods(BindingFlags.Instance |
                                         BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            if (field.IsPublic)
            {
                sb.AppendLine(String.Format("{0} must be private!", field.Name));
            }
        }

        foreach (var method in methods)
        {
            string methodName = method.Name;

            if (methodName.StartsWith("get_") && !method.IsPublic)
            {
                sb.AppendLine(String.Format("{0} have to be public!", methodName));
            }
        }
        
        foreach (var method in methods)
        {
            string methodName = method.Name;

            if (methodName.StartsWith("set_") && method.IsPublic)
            {
                sb.AppendLine(String.Format("{0} have to be private!", methodName));
            }
        }

        return sb.ToString().Trim();
    }

    public string StealFieldInfo(string className, params string[] fields)
    {
        // Get The type of the class
        Type classType = Type.GetType(className);

        // Get All the fields
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Static | BindingFlags.Instance
                                                | BindingFlags.Public | BindingFlags.NonPublic);

        // Create an instance of the class
        var obj = Activator.CreateInstance(classType, new object[] { });

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in fieldsInfo)
        {
            if (Array.IndexOf(fields, field.Name) > -1)
            {
                var fieldName = field.Name;
                var fieldValue = field.GetValue(obj);
                sb.AppendLine(String.Format("{0} = {1}", fieldName, fieldValue));
            }
        }

        return sb.ToString().Trim();
    }
}