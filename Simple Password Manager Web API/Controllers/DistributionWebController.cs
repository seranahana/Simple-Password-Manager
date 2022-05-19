using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplePM.Library.Repositories;
using SimplePM.Library.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime;
using System.Security.Cryptography;

namespace SimplePM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/distributions")]
    public class DistributionWebController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<DistributionWebController> _logger;
        private IUserDataRepository repository;

        public DistributionWebController(ILogger<DistributionWebController> logger, IHttpClientFactory httpClientFactory, IUserDataRepository repository)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this.repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddDistribution([FromBody] UserData newData)
        {
            if (newData == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserData added = await repository.CreateAsync(newData);
                var routeValues = new { id = added.ID };
                var value = added;
                return Created(added.ID, added);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("UNIQUE constraint failed") && ex.InnerException.Message.Contains("login"))
                {
                    return BadRequest("This username has been already occupied");
                }
                return BadRequest($"{ex.GetType().FullName}::{ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateDistribution([FromBody] UserData updatedData, [FromHeader] string encryptedPassword)
        {
            if (updatedData == null || string.IsNullOrWhiteSpace(updatedData.ID))
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(encryptedPassword))
            {
                return Unauthorized("Access denied: No password recieved");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await repository.RetrieveAsync(updatedData.ID);
            if (existing == null)
            {
                return NotFound("No such user found");
            }
            if (existing.MasterPassword == encryptedPassword)
            {
                await repository.UpdateAsync(updatedData.ID, updatedData);
                return new NoContentResult();
            }
            else
            {
                return Unauthorized("Access denied: Wrong password");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveDistribution(string id, [FromHeader] string encryptedPassword)
        {
            if (string.IsNullOrWhiteSpace(encryptedPassword))
            {
                return Unauthorized($"Access denied: No password recieved");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await repository.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound("No such user found");
            }
            if (existing.MasterPassword == encryptedPassword)
            {
                bool? deleted = await repository.DeleteAsync(id);
                if (deleted.HasValue && deleted.Value)
                {
                    return new NoContentResult();
                }
                else
                {
                    return BadRequest($"User {id} was found but failed to delete");
                }
            }
            else
            {
                return Unauthorized("Access denied: Wrong password");
            }
        }
    }
}
