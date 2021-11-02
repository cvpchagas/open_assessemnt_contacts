using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Open.Assessement.Contacts.Crosscutting.Dtos
{
    public class Contact
    {
        [Description("Contact Identifier")]
        public int id { get; set; }

        [Required]
        [Description("Contact Name")]
        public string name { get; set; }

        [Description("Contact CPF Code")]
        public string cpf { get; set; }

        //[Description("Contact Birthday Date")]
        //public DateTime? Birthday { get; set; }

        [Description("Contact Birthday Date String ")]
        public string birthday { get; set; }

        [Description("Contact  Gender" )]
        public string gender { get; set; }

        [Description("Address ZipCode")]
        public string addressZipCode { get; set; }

        [Description("Address Coutry")]
        public string addressCountry { get; set; }

        [Description("Address State")]
        public string addressState { get; set; }

        [Description("Address City")]
        public string addressCity { get; set; }

        [Description("Address Description")]
        public string addressDescription { get; set; }

        [Description("Address Complement")]
        public string addressComplement { get; set; }
    }
}
