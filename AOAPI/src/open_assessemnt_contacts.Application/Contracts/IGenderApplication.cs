using Open.Assessement.Contacts.Crosscutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Application.Contracts
{
    public interface IGenderApplication
    {
        Task<List<Gender>> GetAll();
    }
}
