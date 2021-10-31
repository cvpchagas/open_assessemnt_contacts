using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Open.Assessement.Contacts.Crosscutting.Handler
{
    public static class DefaultHeader
    {
        public static void DefaultRequestHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate");
        }
    }
}
