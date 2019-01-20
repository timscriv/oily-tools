using AutoMapper;
using Clients.Api.Clients.Dtos;
using Clients.Core.Common.ValueObjects;
using OilyTools.Core.Converters;

namespace Clients.Api.Clients.Converters
{
    public class ClientsRequestConverter : BaseConverter<ClientsRequest, ClientsRequestDto>
    {
        private readonly IMapper _mapper;

        public ClientsRequestConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override ClientsRequestDto Convert(ClientsRequest entity)
        {
            return _mapper.Map<ClientsRequestDto>(entity);
        }

        public override ClientsRequest Convert(ClientsRequestDto dto)
        {
            return _mapper.Map<ClientsRequest>(dto);
        }

        public class ClientsRequestConverterProfile : Profile
        {
            public ClientsRequestConverterProfile()
            {
                CreateMap<ClientsRequest, ClientsRequestDto>();
            }
        }
    }
}
