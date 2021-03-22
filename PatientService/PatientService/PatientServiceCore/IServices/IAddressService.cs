using PatientServiceCore.DTOs;
using PatientServiceCore.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientServiceCore.IServices
{
    public interface IAddressService
    {
        public Task<List<AddressDTO>> GetAll();
        public Task<AddressDTO> GetById(int id);
        public Task<PaginatedList<AddressDTO>> GetWithPaging(int? page, int size, string sotrOrder, string filter);
        public Task Add(AddressDTO addressDto);
        public Task Update(AddressDTO addressDto);
        public Task Delete(int id);
    }
}
