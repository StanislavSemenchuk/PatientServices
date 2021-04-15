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
using System.Text;
using System.Threading.Tasks;

namespace PatientServiceCore.Services
{
    public class IllnessService : IIllnessService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public IllnessService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task Add(IllnessDTO illnessDto)
        {
            var illness = illnessDto != null ? _mapper.Map<Illness>(illnessDto) : throw new NullReferenceException();
            await _db.Illnesses.AddAsync(illness);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var illness = await _db.Illnesses.FirstOrDefaultAsync(i => i.Id == id);
            _ = illness != null ? _db.Illnesses.Remove(illness) : throw new Exception("element with this id was not found");
            await _db.SaveChangesAsync();
        }

        public async Task<List<IllnessDTO>> GetAll()
        {
            return _mapper.Map<List<IllnessDTO>>(await _db.Illnesses.ToListAsync()) ?? throw new NullReferenceException();
        }

        public async Task<IllnessDTO> GetById(int id)
        {
            return _mapper.Map<IllnessDTO>(await _db.Illnesses.SingleOrDefaultAsync(i => i.Id == id)) ?? throw new NullReferenceException();
        }

        public async Task<PaginatedList<IllnessDTO>> GetWithPaging(int? page, int size, string sortOrder, string filter)
        {
            var illnesses = string.IsNullOrWhiteSpace(filter) ? _db.Illnesses
                          : _db.Illnesses.Where(i => i.IllName.Contains(filter)
                                                  || i.Type.ToString().Contains(filter));

            illnesses = OrderIllness(sortOrder, illnesses);

            //IQueryable<IllnessDTO> queryable = illnesses.ProjectTo<IllnessDTO>(_mapper.ConfigurationProvider).AsSingleQuery().AsNoTracking();
            var result = _mapper.Map<List<Illness>, List<IllnessDTO>>(await illnesses.ToListAsync());
            var queryResult = result.AsQueryable().AsNoTracking();

            var paginatedList = PaginatedList<IllnessDTO>.Create(queryResult, page ?? 1, size);

            return paginatedList ?? throw new NullReferenceException();
        }

        public async Task Update(int Id, IllnessDTO illnessDto)
        {
            var illness = await _db.Illnesses.SingleOrDefaultAsync(i => i.Id == Id);
            illness = _mapper.Map<Illness>(illnessDto);
            _db.Illnesses.Update(illness);
            _db.SaveChanges();
        }

        private IQueryable<Illness> OrderIllness(string sortOrder, IQueryable<Illness> illnesses)
        {
            switch (sortOrder)
            {
                case "illnessDesc":
                    illnesses = illnesses.OrderByDescending(i => i.IllName);
                    break;
                case "illnessType":
                    illnesses = illnesses.OrderBy(i => i.Type);
                    break;
                case "illnessTypeDesc":
                    illnesses = illnesses.OrderByDescending(i => i.Type);
                    break;
                default:
                    illnesses = illnesses.OrderBy(i => i.IllName);
                    break;
            }
            return illnesses;
        }
    }
}
