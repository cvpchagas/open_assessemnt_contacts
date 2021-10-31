using Open.Assessement.Contacts.Application.Contracts;
using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Domain.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Application.Services
{
    public class GenderApplicationService : IGenderApplication
    {
        private readonly IGenderDomainService _genderDomainService;
        public GenderApplicationService(IGenderDomainService genderdomainservice)
        {
            _genderDomainService = genderdomainservice;
        }
        public async Task<List<Gender>> GetAll()
        => await _genderDomainService.GetAll();
    }
}
