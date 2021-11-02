using System;
using System.Collections.Generic;
using Open.Assessement.Contacts.Crosscutting.Dtos;

namespace Open.Assessement.Contacts.Domain.Contracts.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetDB();
        Contact InsertDB(Contact contact);
        Contact UpadtetDB(Contact contact);
        bool DeleteDB(Contact contact);
    }
}
