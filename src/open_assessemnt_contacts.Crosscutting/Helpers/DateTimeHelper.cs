using System;
using System.Collections.Generic;
using System.Linq;
using Open.Assessement.Contacts.Crosscutting.Utils.Exceptions;

namespace Open.Assessement.Contacts.Crosscutting.Helpers
{
    public static class DateTimeHelper
    {
       
        public static DateTime? ConvertStringToDate(string date)
        {
            if (string.IsNullOrEmpty(date))
                throw new ExceptionBusiness("Date cannot be null!");
            /*else if (date.Split('-').Length < 3 || date.Split('/').Length < 3 || date.Split('\\').Length < 3)
                throw new ExceptionBusiness("Data Inválida");*/

            DateTime? result = DateTime.MinValue;
            char separator = ExtractDateSeparator(date);
            int[] members = date.Split(separator).Select(Int32.Parse).ToArray();
            result = BuildDate(members);

            return result;
        }

        public static char ExtractDateSeparator(string date)
        {
            char separator = char.MinValue;
            if (string.IsNullOrEmpty(date))
                throw new ExceptionBusiness("Date cannnot be null!");
            else if (date.Split('-').Length < 3)
                throw new ExceptionBusiness("Invalid date.");

            if (date.IndexOf('/') > 0)
                separator = '/';
            else if (date.IndexOf('\\') > 0)
                separator = '\\';
            else if (date.IndexOf('-') > 0)
                separator = '-';
            else
                throw new ExceptionBusiness("Invalid date.");

            return separator;
        }

        public static DateTime? BuildDate(int[] dateParts)
        {
            DateTime? result = DateTime.MinValue;
            int day = 0;
            int month = 0;
            int year = 0;

            if (dateParts == null)
                throw new ExceptionBusiness("Invalid date range.");

            if (dateParts[0] > 12)
            {
                day = dateParts[0];
                month = dateParts[1];
                year = dateParts[2];
                result = new DateTime(year, month, day);
            }
            else if (dateParts[1] > 12)
            {
                day = dateParts[1];
                month = dateParts[0];
                year = dateParts[2];
                result = new DateTime(year, month, day);
            }
            else
                result = new DateTime(dateParts[2], dateParts[1], dateParts[0]);
            return result;
        }


        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}