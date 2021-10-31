namespace Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration
{


    public class AOConfigApp
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Appsettings AppSettings { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Appsettings
    {

        public string JosnDbContext { get; set; }
    }

    public class Connectionstrings
    {
        public string OADbContext { get; set; }
    }
}
