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
    [Route("api/v1/[controller]")]
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
        /// Get Contact By Id
        /// </summary>
        /// <param name="id"> Contact Id</param>
        /// <response code="200">Successfully returned the contact.</response> 
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response>  
        [HttpGet("{id:int}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContact(int id)
        {
            try
            {
                var result = await _app.GetContact(id);
                if (result == null)
                {
                    return NotFound($"Contact (Id: {id}) not found.");
                }
                else
                {
                    return Ok(result);
                }

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
        /// <param name="contact"> Objetct type Contact whith informations of contact</param>
        /// <response code="200">Contact created successfully.</response>      
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response> 
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert(Contact contact)
        {
            try
            {
                var result = await _app.Insert(contact);
                return CreatedAtRoute(nameof(GetContact), new { id = result.id }, contact);
                //return Ok(result);
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
        /// <param name="id"> Contact Id</param>
        /// <param name="contact"> Objetct type Contact whith informations of contact</param>
        /// <response code="200">Contact updated successfully.</response>      
        /// <response code="400">Business error was returned.</response>
        /// <response code="500">System error was returned.</response> 
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
        {
            try
            {
                var result= await _app.Update(contact);
                return Ok(result);
                //if(result != null)
                //{
                //    return Ok($"Contact (Name: {result.name}{(string.IsNullOrEmpty(result.cpf) ? "" : $" | CPF: {result.cpf}")}) updated successfully!");
                //}
                //else
                //{
                //    return NotFound($"Contact (Name: {contact.name}{(string.IsNullOrEmpty(contact.cpf) ? "" : $" | CPF: {contact.cpf}")}) not found.");
                //}
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
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _app.Delete(id);
                if (result != null)
                {
                    return Ok($"Contact (Name: {result.name}{(string.IsNullOrEmpty(result.cpf) ? "" : $" | CPF: {result.cpf}")}) removed successfully!");
                }
                else
                {
                    return NotFound($"Cannot found contact with id: {id}.");
                }
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
