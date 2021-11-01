using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Open.Assessement.Contacts.Domain.Contracts.Repositories;
using Open.Assessement.Contacts.Domain.Contracts.Services;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using Open.Assessement.Contacts.Crosscutting.Utils.Exceptions;
using Open.Assessement.Contacts.Crosscutting.Extensions;

namespace Open.Assessement.Contacts.Domain.Services
{
    public class ContactDomainService : IContactDomainService
    {
        private readonly IContactRepository _ContactRepository;
        private readonly IOptions<AOConfigApp> _configClient;
        public ContactDomainService(IContactRepository contactrepository, IOptions<AOConfigApp> configClient)
        {
            _ContactRepository = contactrepository;
            _configClient = configClient;
        }
        public async Task<List<Contact>> GetAll()
        {
            List<Contact> resultlist = new List<Contact>();
            resultlist = _ContactRepository.GetDB();
            return resultlist;
        }

        public async Task<string> Insert(Contact contact)
        {

            Contact contactresult = new Contact();
            string result = string.Empty;
            this.ValidRules(contact);

            if (!string.IsNullOrEmpty(contact.BirthdayString) ) 
                contact.Birthday = contact.BirthdayString.ConvertToDateTime();

            if (_ContactRepository.InsertDB(contact)) contactresult = contact;
            if (contactresult.Id > 0) result = $"Contact {contactresult.Name} (CPF: {contactresult.CPF}) was successfully registered.";

            return result;
        }

        public async Task<string> Update(Contact contact)
        {
            Contact contactresult = new Contact();
            string result = string.Empty;
            if (!string.IsNullOrEmpty(contact.BirthdayString))
                contact.Birthday = contact.BirthdayString.ConvertToDateTime();

            if (_ContactRepository.UpadtetDB(contact)) contactresult = contact;
            if (contactresult.Id > 0) result = $"Contact {contactresult.Name} (CPF: {contactresult.CPF}) has been updated successfully.";
            return result;
        }

        public async Task<string> Delete(int id)
        {
            Contact contactresult = new Contact();
            string result = string.Empty;
            if (id <= 0) throw new ExceptionBusiness($"Contact Id cannot be null.");
            
            var contact = _ContactRepository.GetDB().Where(x => x.Id == id).FirstOrDefault();

            if (contact==null) throw new ExceptionBusiness($"Contact not found with id {id}");
            if (_ContactRepository.DeleteDB(contact)) contactresult = contact;
            if (contactresult.Id > 0) result = $"Contact {contactresult.Name} (CPF: {contactresult.CPF}) has been removed successfully.";


            return result;
        }

        public async Task<bool> CPFValidate(string cpf)
        {
            bool isvalid = false;
            isvalid = this.CPFVerify(cpf);
            if (!isvalid) throw new ExceptionBusiness($"CPF is invalid.");

            return isvalid;
        }

        private void ValidRules(Contact contact, string operation = "insert")
        {
            if (contact == null) throw new ExceptionBusiness($"Contact cannot be null.");
            if (contact != null)
            {
                if (operation == "insert" && contact.Id > 0) throw new ExceptionBusiness($"Contact Id can be null.");
                if (operation == "update" && contact.Id <=0) throw new ExceptionBusiness($"Contact Id cannot be null.");
                if (String.IsNullOrEmpty(contact.Name)) throw new ExceptionBusiness($"Contact's name is required.");
                if(!String.IsNullOrEmpty(contact.CPF))
                {
                    if(! CPFVerify(contact.CPF)) throw new ExceptionBusiness($"The contact's CPF is invalid.");
                    if(operation == "insert")
                    {
                        List<Contact> contacts = new List<Contact>();
                        contacts = _ContactRepository.GetDB().ToList();

                        if (contacts.Count > 0)
                        {
                            int countduplicateds = contacts.Where(x =>
                                                            x.CPF?.ToLower().Trim() == contact.CPF?.ToLower().Trim()
                                                        && x.Name?.ToLower().Trim() == contact.Name?.ToLower().Trim()
                                                        && x.Id != contact.Id
                         ).Count();

                            if (countduplicateds > 0) throw new ExceptionBusiness($"There is already another contact with the same name { contact.Name} and CPF {contact.CPF}.");

                        }
                    }
                    

                    
                    
                }
            }

        }
        private  Boolean CPFVerify(String cpf)
        {
            if (Regex.IsMatch(cpf, @"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)"))
            {
                return IsCpf(cpf);
            }
            else
            {
                return false;
            }
        }
        private static bool IsCpf(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string haspCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(haspCpf[i].ToString()) * multiplier1[i];

            int rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            haspCpf = haspCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(haspCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }
    }
}
