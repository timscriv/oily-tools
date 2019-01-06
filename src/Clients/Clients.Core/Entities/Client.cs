using System;

namespace Clients.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
    }
}