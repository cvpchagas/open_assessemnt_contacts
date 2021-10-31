using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Open.Assessement.Contacts.Domain.Contracts.Repositories;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Open.Assessement.Contacts.Infra.Repositories.Json
{
    public class GenderRepository : IGenderRepository
    {
        private string _connstringOAJson;
        private string tb_name = "Gender.json";
        public GenderRepository(IOptions<AOConfigApp> configClient)
        {
            _connstringOAJson = configClient.Value.AppSettings.JosnDbContext;
        }
        public List<Gender> GetDB()
        {
            List<Gender> genders = new List<Gender>();
            using (StreamReader file = File.OpenText(@$"{_connstringOAJson}{tb_name}"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray o2 = (JArray)JToken.ReadFrom(reader);
                if (o2.Count > 0)
                {
                    foreach (var item in o2)
                    {
                        Gender reg = new Gender();
                        reg.Name = item.ToString();
                        genders.Add(reg);
                    }
                }
            }
            return genders;
        }
    }
}
