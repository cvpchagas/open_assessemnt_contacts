using Open.Assessement.Contacts.Crosscutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Domain.Contracts.Services
{
    public interface IContactDomainService
    {
        Task<List<Contact>> GetAll();
        Task<string> Insert(Contact contact);
        Task<string> Update(Contact contact);
        Task<string> Delete(int id);
        Task<bool> CPFValidate(string cpf);
    }
}
