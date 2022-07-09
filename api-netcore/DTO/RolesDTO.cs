using Sieve.Attributes;
using System;

namespace api_netcore.DTO
{
    public class RolesDTO
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public Guid Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }
        public Guid? create_by { get; set; }
        public DateTime? create_at { get; set; }
    }
}
