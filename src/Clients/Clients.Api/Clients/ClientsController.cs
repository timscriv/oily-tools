using Clients.Api.Clients.Dtos;
using Clients.Core.Common.Entities;
using Clients.Core.Common.Interfaces.Clients.GetClients;
using Clients.Core.Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using OilyTools.Core.Converters;
using System.Collections.Generic;
using System.Linq;

namespace Clients.Api.Clients
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IGetClientsUseCase _getClientsUseCase;
        private readonly IConverter<Client, ClientDto> _clientConverter;
        private readonly IConverter<ClientsRequest, ClientsRequestDto> _clientsRequestConverter;

        public ClientsController(IGetClientsUseCase getClientsUseCase,
            IConverter<Client, ClientDto> clientConverter,
            IConverter<ClientsRequest, ClientsRequestDto> clientsRequestConverter)
        {
            _getClientsUseCase = getClientsUseCase;
            _clientConverter = clientConverter;
            _clientsRequestConverter = clientsRequestConverter;
        }

        [HttpGet]
        public ActionResult<List<ClientDto>> Get([FromQuery] ClientsRequestDto requestDto)
        {
            var request = _clientsRequestConverter.Convert(requestDto);

            var clients = _getClientsUseCase.Execute(request);

            return _clientConverter.Convert(clients).ToList();
        }

        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}
    }
}
