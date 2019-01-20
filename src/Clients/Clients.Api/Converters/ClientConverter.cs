using AutoMapper;
using Clients.Api.Dtos;
using Clients.Core.Entities;
using OilyTools.Core.Converters;

namespace Clients.Api.Converters
{
    public class ClientConverter : BaseConverter<Client, ClientDto>
    {
        private readonly IMapper _mapper;

        public ClientConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override ClientDto Convert(Client entity)
        {
            return _mapper.Map<ClientDto>(entity);
        }

        public override Client Convert(ClientDto dto)
        {
            return _mapper.Map<Client>(dto);
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
