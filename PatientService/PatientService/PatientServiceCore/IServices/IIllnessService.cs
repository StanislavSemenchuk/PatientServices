using PatientServiceCore.DTOs;
using PatientServiceCore.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientServiceCore.IServices
{
    public interface IIllnessService
    {
        public Task<List<IllnessDTO>> GetAll();
        public Task<IllnessDTO> GetById(int id);
        public Task<PaginatedList<IllnessDTO>> GetWithPaging(int? page, int size, string sortOrder, string filter);
        public Task Add(IllnessDTO illnessDto);
        public Task Update(IllnessDTO illnessDto);
        public Task Delete(int id);
    }
}
