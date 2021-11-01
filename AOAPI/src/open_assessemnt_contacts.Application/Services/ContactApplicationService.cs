﻿using Open.Assessement.Contacts.Application.Contracts;
using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Domain.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Application.Services
{
    public class ContactApplicationService : IContactApplication
    {
        private readonly IContactDomainService _ContactDomainService;
        public ContactApplicationService(IContactDomainService contactdomainservice)
        {
            _ContactDomainService = contactdomainservice;
        }

        public async Task<List<Contact>> GetAll()
        => await _ContactDomainService.GetAll();

        public async Task<string> Insert(Contact contact)
        => await _ContactDomainService.Insert(contact);

        public async Task<string> Update(Contact contact)
       => await _ContactDomainService.Update(contact);

        public async Task<string> Delete(int id)
       => await _ContactDomainService.Delete(id);

        public async Task<bool> CPFValidate(string cpf)
       => await _ContactDomainService.CPFValidate(cpf);

    }
}
