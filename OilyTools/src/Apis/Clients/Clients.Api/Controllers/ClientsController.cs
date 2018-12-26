using Clients.Api.Dtos;
using Clients.Core.Entities;
using Clients.Core.Interfaces.UseCases;
using Clients.Core.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using OilyTools.Core.Converters;
using System.Collections.Generic;
using System.Linq;

namespace Clients.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IGetClientsUseCase _getClientsUseCase;
        private readonly IConverter<Client, ClientDto> _converter;

        public ClientsController(IGetClientsUseCase getClientsUseCase,
            IConverter<Client, ClientDto> converter)
        {
            _getClientsUseCase = getClientsUseCase;
            _converter = converter;
        }

        [HttpGet]
        public ActionResult<ClientCollectionDto> Get([FromQuery] ClientsRequest request)
        {
            var clients = _getClientsUseCase.Execute(request);

            return new ClientCollectionDto
            {
                Clients = _converter.Convert(clients).ToList(),
                Metadata = clients.Metadata
            };
        }

        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}
    }
}
