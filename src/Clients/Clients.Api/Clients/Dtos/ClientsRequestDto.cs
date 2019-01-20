namespace Clients.Api.Clients.Dtos
{
    public class ClientsRequestDto
    {
        public int? Year { get; set; }
        public string LastName { get; set; }
        public int Limit { get; set; } = 10;
        public int Offset { get; set; } = 0;
    }
}
