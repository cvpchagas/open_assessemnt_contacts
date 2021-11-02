using Open.Assessement.Contacts.Crosscutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Domain.Contracts.Services
{
    public interface IContactDomainService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetContact(int id);
        Task<Contact> Insert(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<Contact> Delete(int id);
        Task<bool> CPFValidate(string cpf);
    }
}
