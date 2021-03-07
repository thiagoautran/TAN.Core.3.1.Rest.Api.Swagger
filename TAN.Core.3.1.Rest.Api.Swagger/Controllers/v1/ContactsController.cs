using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace TAN.Core._3._1.Rest.Api.Swagger.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Criar contato
        /// </summary>
        /// <remarks>
        ///**Modelo de Dados** *(corpo da requisição, body)*
        ///|Parâmetro|||Obrigatório|Tamanho|Descrição|
        ///|---|---|---|:---:|---|---|
        ///|**name**|||✔️|150|<span>Nome.</span>|
        ///|**fone**|||❌||<span>Número</span><br/><span>Formato: 0 0000-0000.</span>|
        /// </remarks>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <response code="201">chave do contato</response>
        [HttpPost]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = null)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
        public async Task<IActionResult> AddAsync([FromBody][Required] object body)
        {
            try
            {
                return Created(nameof(AddAsync), body);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "AddAsync", new object[] { body });
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [MapToApiVersion("1")]
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