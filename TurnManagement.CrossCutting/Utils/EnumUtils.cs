using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TurnManagement.CrossCutting.Utils
{
    public static class EnumUtils
    {
        public static IDictionary<int, string> ToDictionary<T>()
        {
            var dictionary = new Dictionary<int, string>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                dictionary.Add((int)item, item.ToString());
            }

            return dictionary;
        }

        public static IList<object> ToJson<T>()
        {
            var enumVals = new List<object>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                enumVals.Add(new
                {
                    id = (int)item,
                    code = item.ToString(),
                    name = item.ToString(),
                    description = GetDescriptionAttribute(item)
                });
            }

            return enumVals;
        }

        public static string GetDescriptionAttribute(object value)
        {
            if (value == null)
            {
                return null;
            }

            var descriptionAttribute = GetAttributeFromEnum<DescriptionAttribute>(value);

            return descriptionAttribute != null ? descriptionAttribute.Description : null;
        }

        public static TEnum? TryParseElementName<TEnum>(string elementName) where TEnum : struct
        {
            TEnum? result = null;
            var enumType = typeof(TEnum);
            try
            {
                result = (TEnum)Enum.Parse(enumType, elementName);
            }
            catch (ArgumentException)
            {
                /*leave returning null values.*/
            }

            return result;
        }

        public static IDictionary<TEnum, string> GetAll<TEnum>() where TEnum : struct
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToDictionary(t => t, t => GetDescriptionAttribute(t));
        }

        public static TAttribute GetAttributeFromEnum<TAttribute>(object value) where TAttribute : Attribute
        {
            var pobjType = value.GetType();
            var pobjFieldInfo = pobjType.GetField(Enum.GetName(pobjType, value));

            return pobjFieldInfo.GetCustomAttributes(typeof(TAttribute), false).OfType<TAttribute>().FirstOrDefault();
        }
    }
}
