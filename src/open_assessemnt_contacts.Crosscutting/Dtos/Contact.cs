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
        public int Id { get; set; }

        [Required]
        [Description("Contact Name")]
        public string Name { get; set; }

        [Description("Contact CPF Code")]
        public string CPF { get; set; }

        [Description("Contact Birthday Date")]
        public DateTime? Birthday { get; set; }

        [Description("Contact Birthday Date String ")]
        public string BirthdayString { get; set; }

        [Description("Contact  Gender" )]
        public string Gender { get; set; }

        [Description("Address ZipCode")]
        public string AddressZipCode { get; set; }

        [Description("Address Coutry")]
        public string AddressCountry { get; set; }

        [Description("Address State")]
        public string AddressState { get; set; }

        [Description("Address City")]
        public string AddressCity { get; set; }

        [Description("Address Description")]
        public string AddressDescription { get; set; }

        [Description("Address Complement")]
        public string Addresscomplement { get; set; }
    }
}
