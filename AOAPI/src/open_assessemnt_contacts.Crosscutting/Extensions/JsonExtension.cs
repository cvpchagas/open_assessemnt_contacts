using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Open.Assessement.Contacts.Crosscutting.Extensions
{
    public static  class JsonExtension
    {
        public static dynamic GetContent(string filepath)
        {
            string content = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject(content);
        }
        public static void SalveContent(string filepath, dynamic content, bool indent)
        {
            Formatting format = indent ? Formatting.Indented : Formatting.None;
            string newcontent = JsonConvert.SerializeObject(content, format);
            File.WriteAllText(filepath, newcontent);
        }
        public  static void ReplaceFile(string filepath, Object data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(@$"{filepath}", json);
        }
    }
}
