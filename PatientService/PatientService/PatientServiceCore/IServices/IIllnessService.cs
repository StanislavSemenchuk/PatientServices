using PatientService.Db.Entities;
using System.Threading.Tasks;

namespace PatientServiceCore.IServices
{
    public interface IIllnessService
    {
        public Task<Illness> GetAll();
        public Task<Illness> GetById(int id);
        public Task<Illness> GetWithPaging(int page, int size);
        public Task Add(Illness illness);
        public Task Update(Illness illness);
        public Task Delete(Illness illness);
        public Task DeleteById(int id);
    }
}
