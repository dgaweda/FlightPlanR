using System.Reflection;

namespace FlightPlanApi.Common.Enums;

public static class EnumExtension
{
    public static string EnumDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo != null)
        {
            return value.ToString();
        }
        
        var attributes = fieldInfo?.GetCustomAttributes(typeof(EnumDescriptionAttribute), false) as EnumDescriptionAttribute[];
        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}