using Open.Assessement.Contacts.Application.Contracts;
using Open.Assessement.Contacts.Crosscutting.Utils.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Open.Assessement.Contacts.Crosscutting.Dtos;

namespace Open.Assessement.Contacts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactApplication _app;
        public ContactController(IContactApplication app)
        {
            _app = app;
        }

        /// <summary>
        /// Get All Contacts
        /// </summary>
        /// <response code="200">Successfully returned the contacts list.</response>      
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response>  
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _app.GetAll();
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (ExceptionBusiness exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Craeate a new Contact
        /// </summary>
        /// <response code="200">Contact created successfully.</response>      
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response> 
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            try
            {
                var result = await _app.Insert(contact);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (ExceptionBusiness exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update Contact Informations
        /// </summary>
        /// <response code="200">Contact updated successfully.</response>      
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response> 
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Contact contact)
        {
            try
            {
                var result = await _app.Update(contact);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (ExceptionBusiness exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Remove Contact
        /// </summary>
        /// <response code="200">Contact successfully removed.</response>      
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response> 
        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var result = await _app.Delete(id);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (ExceptionBusiness exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        /// <summary>
        /// Validate Contact`s CPF 
        /// </summary>
        /// <returns></returns>
        [HttpGet("CPFValidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CPFValidate([FromQuery] string cpf)
        {
            try
            {
                var result = await _app.CPFValidate(cpf);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (ExceptionBusiness exb)
            {
                return BadRequest(exb.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
