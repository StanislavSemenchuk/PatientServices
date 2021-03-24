using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PatientService.Db.Ef;
using PatientService.Db.Entities;
using PatientServiceCore.DTOs;
using PatientServiceCore.Helpers;
using PatientServiceCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientServiceCore.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AddressService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Add(AddressDTO addressDto)
        {
            var address = addressDto != null ? _mapper.Map<Address>(addressDto) : throw new NullReferenceException();
            await _db.Addresses.AddAsync(address);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(p => p.Id == id);
            _ = address != null ? _db.Addresses.Remove(address) : throw new Exception("element with this id was not found");
            await _db.SaveChangesAsync();
        }

        public async Task<List<AddressDTO>> GetAll()
        {
            return _mapper.Map<List<AddressDTO>>(await _db.Addresses.ToListAsync()) ?? throw new NullReferenceException();
        }

        public async Task<AddressDTO> GetById(int id)
        {
            return _mapper.Map<AddressDTO>(await _db.Addresses.SingleOrDefaultAsync(a => a.Id == id)) ?? throw new NullReferenceException();
        }

        public async Task<PaginatedList<AddressDTO>> GetWithPaging(int? page, int size, string sortOrder, string filter)
        {
            var addresses = string.IsNullOrWhiteSpace(filter) ? _db.Addresses
                          : _db.Addresses.Where(a => a.City.Contains(filter)
                                                  || a.Country.Contains(filter)
                                                  || a.State.Contains(filter)
                                                  || a.ZipCode.Contains(filter)
                                                  || a.Patient.Name.Contains(filter));

            addresses = OrderAddress(sortOrder, addresses);

            IQueryable<AddressDTO> queryable = addresses.ProjectTo<AddressDTO>(_mapper.ConfigurationProvider).AsQueryable();

            var paginatedList = await PaginatedList<AddressDTO>.CreateAsync(queryable.AsNoTracking(), page ?? 1, size);

            return paginatedList ?? throw new NullReferenceException();
        }

        public async Task Update(AddressDTO addressDto)
        {
            var address = await _db.Addresses.SingleOrDefaultAsync(a => a.Id == addressDto.Id);
            address = _mapper.Map<Address>(addressDto);
            _db.Addresses.Update(address);
            _db.SaveChanges();
        }

        private IQueryable<Address> OrderAddress(string sortOrder, IQueryable<Address> addresses)
        {
            switch (sortOrder)
            {
                case "countryDesc":
                    addresses = addresses.OrderByDescending(a => a.Country);
                    break;
                case "city":
                    addresses = addresses.OrderBy(a => a.City);
                    break;
                case "cityDesc":
                    addresses = addresses.OrderByDescending(a => a.City);
                    break;
                case "state":
                    addresses = addresses.OrderBy(a => a.State);
                    break;
                case "stateDesc":
                    addresses = addresses.OrderByDescending(a => a.State);
                    break;
                case "zipCode":
                    addresses = addresses.OrderBy(a => a.ZipCode);
                    break;
                case "zipCodeDesc":
                    addresses = addresses.OrderByDescending(a => a.ZipCode);
                    break;
                case "patient":
                    addresses = addresses.OrderBy(a => a.Patient.Name);
                    break;
                case "patientDesc":
                    addresses = addresses.OrderByDescending(a => a.Patient.Name);
                    break;
                default:
                    addresses = addresses.OrderBy(a => a.Country);
                    break;
            }
            return addresses;
        }
    }
}
