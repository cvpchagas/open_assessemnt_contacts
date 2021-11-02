using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Open.Assessement.Contacts.Domain.Contracts.Repositories;
using Open.Assessement.Contacts.Crosscutting.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Open.Assessement.Contacts.Infra.Repositories.Json
{ 
    public class ContactRepository : IContactRepository
    {
        private string _connstringOAJson;
        private string tb_name = "Contact.json";
        public ContactRepository(IOptions<AOConfigApp> configClient)
        {
            _connstringOAJson = configClient.Value.AppSettings.JosnDbContext;
        }
        public List<Contact> GetDB()
        {
            List<Contact> genders = new List<Contact>();
            try
            {
                using (StreamReader file = File.OpenText(@$"{_connstringOAJson}{tb_name}"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JArray o2 = (JArray)JToken.ReadFrom(reader);
                    if (o2.Count > 0)
                    {
                        foreach (var item in o2)
                        {

                            Contact reg = new Contact();
                            reg.id = int.Parse(item["id"].ToString());
                            reg.name = item["name"].ToString();
                            reg.cpf = item["cpf"].ToString();
  
                            reg.birthday = item["birthday"].ToString();
                            reg.gender = item["gender"].ToString();
                            reg.addressCountry = item["addressCountry"].ToString();
                            reg.addressZipCode = item["addressZipCode"].ToString();
                            reg.addressState = item["addressState"].ToString();
                            reg.addressCity = item["addressCity"].ToString();
                            reg.addressDescription = item["addressDescription"].ToString();
                            reg.addressComplement = item["addressComplement"].ToString();

                            genders.Add(reg);
                        }
                    }
                }
                return genders.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }

        public Contact InsertDB( Contact contact)
        {
            Contact result = new Contact();
            int idNewItem = 1;
            try
            {
                if(contact != null)
                {
                    List<Contact> contacts = new List<Contact>();
                    contacts = this.GetDB().ToList();
                    if (contacts.Count > 0)
                    {
                        idNewItem = contacts.OrderByDescending(i => i.id).Select(x => x.id).FirstOrDefault() + 1;
                        contact.id = idNewItem;
                        contacts = contacts.OrderBy(x => x.id).ToList();
                    }
                    contact.id = idNewItem;
                    contacts.Add(contact);
                    string filepath = @$"{_connstringOAJson}{tb_name}";
                    JsonExtension.ReplaceFile(filepath, contacts);
                    result = contact;
                }
                return contact;
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact UpadtetDB(Contact contact)
        {
            Contact result = new Contact();
            try
            {
                if (contact != null)
                {
                    List<Contact> contacts = new List<Contact>();
                    contacts = this.GetDB().ToList();
                    if (contacts.Count > 0)
                    {
                        var contactold = contacts.Where(x => x.id == contact.id).FirstOrDefault();
                        contacts.Remove(contactold);
                        contacts.Add(contact);
                        contacts = contacts.OrderBy(x => x.id).ToList();
                        string filepath = @$"{_connstringOAJson}{tb_name}";
                        JsonExtension.ReplaceFile(filepath, contacts);

                        result = contact;
                    }
   
                    
                }
                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteDB(Contact contact)
        {
            bool result = false;
            try
            {
                if (contact != null)
                {
                    List<Contact> contacts = new List<Contact>();
                    contacts = this.GetDB().ToList();
                    if (contacts.Count > 0)
                    {
                        var contactold = contacts.Where(x => x.id == contact.id).FirstOrDefault();
                        contacts.Remove(contactold);
                        contacts = contacts.OrderBy(x => x.id).ToList();
                        string filepath = @$"{_connstringOAJson}{tb_name}";
                        JsonExtension.ReplaceFile(filepath, contacts);

                        result = true;
                    }


                }
                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
