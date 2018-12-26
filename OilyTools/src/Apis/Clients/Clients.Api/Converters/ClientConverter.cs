using AutoMapper;
using Clients.Api.Dtos;
using Clients.Core.Entities;
using OilyTools.Core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.Api.Converters
{
    public class ClientConverter : IConverter<Client, ClientDto>
    {
        private readonly IMapper _mapper;

        public ClientConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ClientDto Convert(Client entity)
        {
            return _mapper.Map<ClientDto>(entity);
        }

        public Client Convert(ClientDto dto)
        {
            return _mapper.Map<Client>(dto);
        }

        public IEnumerable<ClientDto> Convert(IEnumerable<Client> entities)
        {
            return _mapper.Map<IEnumerable<ClientDto>>(entities);
        }

        public IEnumerable<Client> Convert(IEnumerable<ClientDto> dtos)
        {
            return _mapper.Map<IEnumerable<Client>>(dtos);
        }

        public class ClientConverterProfile : Profile
        {
            public ClientConverterProfile()
            {
                CreateMap<Client, ClientDto>();
            }
        }
    }
}
