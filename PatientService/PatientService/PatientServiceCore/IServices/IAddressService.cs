using PatientService.Db.Entities;
using System.Threading.Tasks;

namespace PatientServiceCore.IServices
{
    public interface IAddressService
    {
        public Task<Address> GetAll();
        public Task<Address> GetById(int id);
        public Task<Address> GetWithPaging(int page, int size);
        public Task Add(Address address);
        public Task Update(Address address);
        public Task Delete(Address address);
        public Task DeleteById(int id);
    }
}
