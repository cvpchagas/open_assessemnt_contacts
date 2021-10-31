using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Open.Assessement.Contacts.Crosscutting.Extensions
{
    public static class StringExtension
    {
        public static DateTime ConvertToDateTime(this string value)
        {

            if (DateTime.TryParse(value, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime _))
                return DateTime.Parse(value, new CultureInfo("pt-BR"));
            else if (DateTime.TryParseExact(value, "yyyymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _))
                return DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture);
            else
                return default;

        }

        public static bool ConvertToBoolean(this string value)
        => value.Equals("1") || value.ToLower().Equals("true");

        public static string ToTitleCase(this string value)
        {
            var textInfo = new CultureInfo("pt-BR", false).TextInfo;
            return textInfo.ToTitleCase(value);
        }

        public static int ConvertDateTimeToSeconds(this string value)
        {
            var isValidDate = DateTime.TryParse(value, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime _);

            var date = isValidDate ? DateTime.Parse(value, new CultureInfo("pt-BR")) : default;

            if (date == default)
                return 0;

            var seconds = date.Minute * 60;
            seconds += date.Second;

            return seconds;
        }

        public static string ReplaceAllWhiteSpaces(this string value)
            => Regex.Replace(value, @"\s+", String.Empty); 

    }
}
