using PatientService.Db.Entities;
using PatientServiceCore.DTOs;
using PatientServiceCore.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientServiceCore.IServices
{
    public interface IPatientService
    {
        public Task<List<PatientDTO>> GetAll();
        public Task<PatientDTO> GetById(int Id);
        public Task<PaginatedList<PatientDTO>> GetWithPaging(int? page, int size, string sotrOrder, string filter);
        public Task Add(PatientDTO patientDto);
        public Task Update(int id, PatientDTO patientDto);
        public Task Delete(int id);
    }
}
