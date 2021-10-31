using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Open.Assessement.Contacts.Crosscutting.Extensions
{ 
    public static class IntExtension
    {
        public static bool ConvertToBoolean(this int value)
         => value.Equals(1);


        public static string ConvertToDateFormated(this int value)
        {
            TimeSpan ts = TimeSpan.FromSeconds(value);
            return new DateTime(ts.Ticks).ToString("HH:mm:ss");

        }
    }
}
