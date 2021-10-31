using Open.Assessement.Contacts.Crosscutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Domain.Contracts.Services
{
    public interface ICountryDomainService
    {
         Task<List<Country>> GetAll();
    }
}
