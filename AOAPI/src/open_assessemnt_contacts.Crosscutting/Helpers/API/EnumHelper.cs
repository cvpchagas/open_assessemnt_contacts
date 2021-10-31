using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Open.Assessement.Contacts.Crosscutting.Helpers.API
{
    public static class EnumHelper
    {
        public static List<TextValueType> GetEnumList<T>(int valuePadLeftCount = 0,  char charValuePadLeft = default(char))
        {
            var list = new List<TextValueType>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                T enumType = (T)e;
                string value = ((int)e).ToString();

                if (valuePadLeftCount > 0)
                    value = value.PadLeft(valuePadLeftCount, charValuePadLeft);

                list.Add(new TextValueType(GetEnumDescription(enumType), value));
            }
            return list;
        }

        public static List<string> GetEnumList<T>()
        {
            var enumVals = new List<string>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var type = item.GetType();

                MemberInfo[] memInfo = type.GetMember(item.ToString());
                DescriptionAttribute[] attributes = memInfo[0].GetCustomAttributes<DescriptionAttribute>(false).ToArray();

                enumVals.Add(attributes[0].Description.ToString()); 
            }

            return enumVals;
        }




        public static string GetEnumDescription<T>(T value) 
        {
            try
            {
                if (value.Equals(default(T)))
                    return string.Empty;
                Type type = typeof(T);
                if(type.IsGenericType)
                {
                    type = type.GenericTypeArguments[0];
                }

                var name = Enum.GetNames(type).Where(f => f.Equals(value.ToString(), StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();
                if (name == null) return string.Empty;
                var field = type.GetField(name);
                var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

		public static string GetStringValue(this Enum value)
		{
			string stringValue = value.ToString();
			Type type = value.GetType();
			FieldInfo fieldInfo = type.GetField(value.ToString());
			StringValue[] attrs = fieldInfo.
				GetCustomAttributes(typeof(StringValue), false) as StringValue[];
			if (attrs.Length > 0)
			{
				stringValue = attrs[0].Value;
			}
			return stringValue;
		}

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Enum não encontrado pela descrição {description}", nameof(description));
            // or return default(T);
        }
    }
}