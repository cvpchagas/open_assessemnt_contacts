using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Open.Assessement.Contacts.Crosscutting.Extensions
{
    public static class FormFileExtension
    {
        public static Stream ConvertToStream(this IFormFile value)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return value.OpenReadStream();
        }     
    }
}
