using System;
using System.Reflection;
using System.Text;

public class Spy
{
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
            if(Array.IndexOf(fields, field.Name) > -1)
            {
                var fieldName = field.Name;
                var fieldValue = field.GetValue(obj);
                sb.AppendLine(String.Format("{0} = {1}", fieldName, fieldValue));
            }
        }

        return sb.ToString().Trim();
    }
}