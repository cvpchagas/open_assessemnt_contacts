using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Open.Assessement.Contacts.Domain.Contracts.Repositories;
using Open.Assessement.Contacts.Domain.Contracts.Services;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Domain.Services
{
    public class CountryDomainService: ICountryDomainService
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IOptions<AOConfigApp> _configClient;
        public CountryDomainService(ICountryRepository countryrepository, IOptions<AOConfigApp> configClient)
        {
            _CountryRepository = countryrepository;
            _configClient = configClient;
        }
        public async Task<List<Country>> GetAll()
        {
            List<Country> resultlist = new List<Country>();
            resultlist = _CountryRepository.GetDB();
            return resultlist;
        } 
    }
}
