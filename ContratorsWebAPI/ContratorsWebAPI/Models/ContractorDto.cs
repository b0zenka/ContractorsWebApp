using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI.Models
{
    public class ContractorDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string NIP { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
