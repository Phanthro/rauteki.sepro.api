using System.ComponentModel;

namespace Rauteki.Fire.Api.Misc.Extensions;
public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        if(fieldInfo is null) return "";

        var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return attribute == null ? value.ToString() : attribute.Description;
    }
}