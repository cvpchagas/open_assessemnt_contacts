using Open.Assessement.Contacts.Crosscutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Application.Contracts
{
    public interface ICountryApplication
    {
        Task<List<Country>> GetAll();
    }
}
