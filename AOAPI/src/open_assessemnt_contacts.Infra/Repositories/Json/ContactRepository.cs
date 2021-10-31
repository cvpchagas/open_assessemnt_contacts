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
                            reg.Id = int.Parse(item["Id"].ToString());
                            reg.Name = item["Name"].ToString();
                            reg.CPF = item["CPF"].ToString();
                            if (!string.IsNullOrEmpty(item["Birthday"].ToString()))
                            {
                                reg.Birthday = item["Birthday"].ToString().ConvertToDateTime();
                                reg.BirthdayString = item["Birthday"].ToString();
                            } 
                            reg.Gender = item["Name"].ToString();
                            reg.AddressCountry = item["AddressCountry"].ToString();
                            reg.AddressZipCode = item["AddressZipCode"].ToString();
                            reg.AddressState = item["AddressState"].ToString();
                            reg.AddressCity = item["AddressCity"].ToString();
                            reg.AddressDescription = item["AddressDescription"].ToString();
                            reg.Addresscomplement = item["Addresscomplement"].ToString();

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

        public bool InsertDB( Contact contact)
        {
            bool result = false;
            int idNewItem = 1;
            try
            {
                if(contact != null)
                {
                    List<Contact> contacts = new List<Contact>();
                    contacts = this.GetDB().ToList();
                    if (contacts.Count > 0)
                    {
                        idNewItem = contacts.OrderByDescending(i => i.Id).Select(x => x.Id).FirstOrDefault() + 1;
                        contact.Id = idNewItem;
                        contacts = contacts.OrderBy(x => x.Id).ToList();
                    }
                    contact.Id = idNewItem;
                    contacts.Add(contact);
                    string filepath = @$"{_connstringOAJson}{tb_name}";
                    JsonExtension.ReplaceFile(filepath, contacts);
                    result = true;
                }
                return result;
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpadtetDB(Contact contact)
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
                        var contactold = contacts.Where(x => x.Id == contact.Id).FirstOrDefault();
                        contacts.Remove(contactold);
                        contacts.Add(contact);
                        contacts = contacts.OrderBy(x => x.Id).ToList();
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
                        var contactold = contacts.Where(x => x.Id == contact.Id).FirstOrDefault();
                        contacts.Remove(contactold);
                        contacts = contacts.OrderBy(x => x.Id).ToList();
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
