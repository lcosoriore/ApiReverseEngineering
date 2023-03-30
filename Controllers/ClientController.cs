using ApiReverseEngineering.Interfaces;
using ApiReverseEngineering.Models;
using ApiReverseEngineering.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiReverseEngineering.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        IClient clientServices;
        private readonly ILogger<ClientController> _logger;
        public ClientController(IClient clientService, ILogger<ClientController> logger)
        {
            clientServices = clientService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Se Se obtiene datos del cliente para autenticacion");
            return Ok(clientServices.Get());
        }

        [HttpPost]
        public async  Task<IActionResult> Post(ClientRequestModel client)
        {
            await clientServices.Save(client);
            return Ok();
        }

        

    }
}
