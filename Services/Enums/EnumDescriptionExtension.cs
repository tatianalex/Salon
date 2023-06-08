using System.ComponentModel;

namespace Services.Enums;

public static class EnumDescriptionExtension
{
    public static string? GetDescription(this Enum @enum)
    {
        return GetEnumDescription(@enum);
    }

    /// <summary>
    /// Ищет кастомный атрибут Description и возвращает его значение
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string? GetEnumDescription(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());

        var attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes is { Length: > 0 }
            ? attributes[0].Description
            : null;
    }
    
}