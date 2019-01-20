using AutoMapper;
using Clients.Api.Clients.Dtos;
using Clients.Core.Common.Entities;
using OilyTools.Core.Converters;

namespace Clients.Api.Clients.Converters
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
