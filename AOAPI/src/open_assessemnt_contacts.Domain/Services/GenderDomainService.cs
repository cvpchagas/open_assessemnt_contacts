using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Open.Assessement.Contacts.Domain.Contracts.Repositories;
using Open.Assessement.Contacts.Domain.Contracts.Services;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Domain.Services
{
    public class GenderDomainService: IGenderDomainService
    {
        private readonly IGenderRepository _GenderRepository;
        private readonly IOptions<AOConfigApp> _configClient;
        public GenderDomainService(IGenderRepository genderepository, IOptions<AOConfigApp> configClient)
        {
            _GenderRepository = genderepository;
            _configClient = configClient;
        }
        public async Task<List<Gender>> GetAll()
        {
            List<Gender> resultlist = new List<Gender>();
            resultlist = _GenderRepository.GetDB();
            return resultlist;
        }
    }
}
