using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplePM.Library.Repositories;
using SimplePM.Library.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplePM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/entries")]
    public class EntriesWebController : ControllerBase
    {
        private IEntryRepository repository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<EntriesWebController> _logger;

        public EntriesWebController(IEntryRepository repository, IHttpClientFactory httpClientFactory, ILogger<EntriesWebController> logger)
        {
            this.repository = repository;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        
        [HttpPost("{ownerID}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SynchronizeEntries(string ownerID, [FromBody] List<Entry> clientBase)
        {
            if (ownerID == null || string.IsNullOrWhiteSpace(ownerID) || clientBase == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                List<Entry> serverBase = await repository.SynchronizeAsync(ownerID, clientBase);
                return Created(ownerID, serverBase);
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://localhost:5001/api/entries/failed-to-synchronize",
                    Title = $"{ex.GetType()}",
                    Detail = ex.Message,
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }
        }
    }
}
