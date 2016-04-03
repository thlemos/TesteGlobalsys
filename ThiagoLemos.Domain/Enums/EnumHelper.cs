using System;
using System.ComponentModel;
using System.Reflection;

namespace ThiagoLemos.Domain.Enums
{
    public static class EnumHelper
    {
        public static string Descricao(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        } 
    }
}