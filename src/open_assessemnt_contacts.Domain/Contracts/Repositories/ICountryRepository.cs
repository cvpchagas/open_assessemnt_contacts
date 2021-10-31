using System;
using System.Collections.Generic;
using Open.Assessement.Contacts.Crosscutting.Dtos;

namespace Open.Assessement.Contacts.Domain.Contracts.Repositories
{
    public interface ICountryRepository
    {
        List<Country> GetDB();
    }
}
