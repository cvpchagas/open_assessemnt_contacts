using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Open.Assessement.Contacts.Crosscutting.Extensions
{
    public static class EnumExtension
    {
         
        public static string ConvertToDescription(this Enum value)
        { 
            var type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());
            DescriptionAttribute[] attributes = memInfo[0].GetCustomAttributes<DescriptionAttribute>(false).ToArray();

            return attributes[0].Description.ToString(); 
        }
    }
}
