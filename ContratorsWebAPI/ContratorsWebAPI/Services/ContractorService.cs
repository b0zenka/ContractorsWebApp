using AutoMapper;
using ContratorsWebAPI.Entities;
using ContratorsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI.Services
{
    public interface IContractorService
    {
        ContractorDto GetbyId(int id);
        IEnumerable<ContractorDto> GetAll();
        int Create(ContractorDto dto);
        bool Delete(int id);
        bool Update(int id, ContractorDto dto);
    }

    public class ContractorService : IContractorService
    {
        private readonly ContractorDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContractorService(ContractorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ContractorDto GetbyId(int id)
        {
            var contractor = _dbContext
                .Contractors
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);

            if (contractor is null)
                return null;
            

            var contractorDto = _mapper.Map<ContractorDto>(contractor);
            return contractorDto;
        }

        public IEnumerable<ContractorDto> GetAll()
        {
            var contractors = _dbContext
                .Contractors
                .Include(c => c.Address)
                .ToList();

            var contractorDtos = _mapper.Map<List<ContractorDto>>(contractors);
            return contractorDtos;
        }

        public int Create(ContractorDto dto)
        {
            var contractor = _mapper.Map<Contractor>(dto);
            _dbContext.Contractors.Add(contractor);
            _dbContext.SaveChanges();

            return contractor.Id;
        }

        public bool Delete(int id)
        {
            var contractor = _dbContext
                .Contractors
                .FirstOrDefault(c => c.Id == id);
            if (contractor is null)
                return false;

            var address = _dbContext
                .Addresses
                .FirstOrDefault(a => a.Id == contractor.AddressId);

            _dbContext.Contractors.Remove(contractor);
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, ContractorDto dto)
        {
            var contractor = _dbContext
                .Contractors
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);
            
            if (contractor is null)
                return false;
            var contractorDto = _mapper.Map<Contractor>(dto);

            contractor.ShortName = contractorDto.ShortName;
            contractor.Name = contractorDto.Name;
            contractor.NIP = contractor.NIP;
            contractor.ContactEmail = contractorDto.ContactEmail;
            contractor.ContactNumber = contractorDto.ContactNumber;
            contractor.Address.Country = contractorDto.Address.Country;
            contractor.Address.City = contractorDto.Address.City;
            contractor.Address.Street = contractorDto.Address.Street;
            contractor.Address.PostalCode = contractorDto.Address.PostalCode;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
