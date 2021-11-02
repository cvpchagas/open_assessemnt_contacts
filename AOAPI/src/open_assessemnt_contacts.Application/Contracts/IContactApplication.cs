using Open.Assessement.Contacts.Crosscutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Application.Contracts
{
    public interface IContactApplication
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetContact(int id);
        Task<Contact> Insert(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<Contact> Delete(int id);
        Task<bool> CPFValidate(string cpf);
    }
}
