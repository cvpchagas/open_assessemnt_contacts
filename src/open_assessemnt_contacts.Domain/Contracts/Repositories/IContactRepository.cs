using System;
using System.Collections.Generic;
using Open.Assessement.Contacts.Crosscutting.Dtos;

namespace Open.Assessement.Contacts.Domain.Contracts.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetDB();
        bool InsertDB(Contact contact);
        bool UpadtetDB(Contact contact);
        bool DeleteDB(Contact contact);
    }
}
