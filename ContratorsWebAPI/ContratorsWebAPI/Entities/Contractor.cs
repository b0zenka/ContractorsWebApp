using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
