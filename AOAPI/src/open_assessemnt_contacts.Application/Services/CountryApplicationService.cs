using Open.Assessement.Contacts.Application.Contracts;
using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Domain.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Application.Services
{
   public class CountryApplicationService: ICountryApplication
    {
        private readonly ICountryDomainService _countryDomainService;
        public CountryApplicationService(ICountryDomainService countrydomainservice)
        {
            _countryDomainService = countrydomainservice;
        }
        public async Task<List<Country>> GetAll()
        => await _countryDomainService.GetAll();
    }
}
