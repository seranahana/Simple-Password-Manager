using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SimplePM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/connectiontest")]
    public class ConnectivityWebController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ConnectivityWebController> _logger;

        public ConnectivityWebController(ILogger<ConnectivityWebController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(OkResult))]
        public OkResult TestConnectivity()
        {
            return Ok();
        }
    }
}