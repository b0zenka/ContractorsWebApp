using ContratorsWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI
{
    public class ContractorsSeeder
    {
        private readonly ContractorDbContext _dbContext;
        public ContractorsSeeder(ContractorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Contractors.Any())
                {
                    var contractors = GetContractors();
                    _dbContext.Contractors.AddRange(contractors);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Contractor> GetContractors()
        {
            var contractors = new List<Contractor>()
            {
                new Contractor()
                {
                    ShortName = "IFirma",
                    Name = "IFirma SA",
                    NIP = "1234567890",
                    ContactEmail = "ifirma@mail.pl",
                    ContactNumber = "",
                    Address = new Address()
                    {
                        Country = "Polska",
                        City = "Wrocław",
                        Street = "Wesoła 1",
                        PostalCode = "53-234"
                    }
                },
                new Contractor()
                {
                    ShortName = "IFirma2",
                    Name = "IFirma2 Sp. z o.o.",
                    NIP = "9876543210",
                    ContactEmail = "ifirma2@mail.pl",
                    ContactNumber = "",
                    Address = new Address()
                    {
                        Country = "Polska",
                        City = "Wrocław",
                        Street = "Kwiatowa 44B",
                        PostalCode = "53-234"
                    }
                }
            };
            return contractors;
        }

    }
}
