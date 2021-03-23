using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTools.Services
{
    public static class EnumHelper
    {
        public static List<KeyValuePair<T, string>> GetEnumValueDescriptionPairs<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(value => new KeyValuePair<T, string>
                (
                    value,
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description
                ))
                .ToList();
        } 
    }
}
