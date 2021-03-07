using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace TAN.Core._3._1.Rest.Api.Swagger.Controllers.v2
{
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/contacts")]
    [Produces("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
        public async Task<IActionResult> ListAsync([FromQuery(Name = "page")] int? page)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ListWithMateraAccountIdAsync", new object[] { page });
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}