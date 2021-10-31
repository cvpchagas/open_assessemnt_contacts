using Open.Assessement.Contacts.Application.Contracts;
using Open.Assessement.Contacts.Crosscutting.Dtos;
using Open.Assessement.Contacts.Crosscutting.Enums;
using Open.Assessement.Contacts.Crosscutting.Utils;
using Open.Assessement.Contacts.Crosscutting.Utils.SystemConfiguration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Open.Assessement.Contacts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtilsController : ControllerBase
    {
        private readonly IOptions<AOConfigApp> _config;
        private readonly IUtilsApplication _utilsApplication;


        public UtilsController(IOptions<AOConfigApp> config, IUtilsApplication utilsApplication)
        {
            _config = config;
            _utilsApplication = utilsApplication;
        }

        [HttpGet]
        public IActionResult EncryptDate()
        {
            var date = DateTime.Now.AddDays(1);
            return Ok(Encrypt.EncryptString(date.ToString()));
        }

        [HttpGet]
        [Route("Encrypt/Validate/{dateEncrypted}")]
        public IActionResult ValidateEncryptedDate(string dateEncrypted)
        {
            string dateEncryptedDecoded = HttpUtility.HtmlDecode(dateEncrypted);
            dateEncryptedDecoded = dateEncryptedDecoded.Replace("%2F", "/");
            DateTime? extractDate = DateTime.Parse(Encrypt.DecryptString(dateEncryptedDecoded));
            if (extractDate.Value == DateTime.Now.Date)
                return Ok();
            else
                return BadRequest("Data Inválida");
        }

        [HttpGet]
        [Route("Encrypt/{stringToEncrypt}")]
        public IActionResult EncryptString(string stringToEncrypt)
        {
            string stringEncryptedDecoded = stringToEncrypt.Replace("%2F", "/");
            return Ok(Encrypt.EncryptString(stringEncryptedDecoded));
        }

        [HttpGet]
        [Route("Decrypt/{stringToDecrypt}")]
        public IActionResult DecryptString(string stringToDecrypt)
        {
            string stringDecryptedDecoded = stringToDecrypt.Replace("%2F", "/");
            var result = Encrypt.DecryptString(stringDecryptedDecoded);
            return Ok($"Resultado: {result}");
        }

        [HttpGet]
        [Route("RegionConfig")]
        public IActionResult CheckServerDateFormats()
        {
            string[] formats = {"d", "D", "f", "F", "g", "G", "m", "o", "r",
                                "s", "t", "T", "u", "U", "Y"};
            List<string> response = new List<string>();
            // Create an array of four cultures.
            CultureInfo[] cultures = {
                /*
                                CultureInfo.CreateSpecificCulture("de-DE"),
                                CultureInfo.CreateSpecificCulture("en-US"),
                                CultureInfo.CreateSpecificCulture("es-ES"),
                                CultureInfo.CreateSpecificCulture("fr-FR")*/
                                CultureInfo.CreateSpecificCulture("pt-BR")
                                };
            // Define date to be displayed.
            DateTime dateToDisplay = DateTime.Now.Date;
            response.Add($"{dateToDisplay.ToString()}");
            // Iterate each standard format specifier.
            foreach (string formatSpecifier in formats)
            {
                foreach (CultureInfo culture in cultures)
                    response.Add($"{formatSpecifier} Format Specifier {culture.Name} Culture {dateToDisplay.ToString(formatSpecifier, culture)})");
            }
            return Ok(response.ToArray());
        } 
    }
}