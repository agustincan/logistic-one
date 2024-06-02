using Common.Core.Domain;
using System;

namespace Transport.Domain.Models
{
    public class Company : EntityBaseGeneric<int>
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public byte Test { get; set; }
    }
}
