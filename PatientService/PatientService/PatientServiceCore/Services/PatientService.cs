using PatientService.Db.Ef;
using PatientService.Db.Entities;
using PatientServiceCore.IServices;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PatientServiceCore.Helpers;
using System;
using AutoMapper;
using PatientServiceCore.DTOs;

namespace PatientServiceCore.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PatientService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(PatientDTO patientDto)
        {
            var patient = patientDto != null ? _mapper.Map<Patient>(patientDto) : throw new NullReferenceException();
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
            _ = patient != null ? _db.Patients.Remove(patient) : throw new Exception("element with this id was not found");
            await _db.SaveChangesAsync();
        }

        public async Task<List<PatientDTO>> GetAll()
        {
            return _mapper.Map<List<PatientDTO>>(await _db.Patients.ToListAsync()) ?? throw new NullReferenceException();
        }

        public async Task<PatientDTO> GetById(int Id)
        {
            return _mapper.Map<PatientDTO>(await _db.Patients.FirstOrDefaultAsync(p => p.Id == Id)) ?? throw new NullReferenceException();
        }
        
        public async Task<PaginatedList<PatientDTO>> GetWithPaging(int? page, int size, string sortOrder, string filter) 
        {
            var patients = string.IsNullOrWhiteSpace(filter) ? _db.Patients
                          : _db.Patients.Where(p => p.Name.Contains(filter)
                                                 || p.Email.Contains(filter)
                                                 || p.DayOfBirdth.ToShortDateString().Contains(filter)
                                                 || p.PhoneNumber.Contains(filter)
                                                 || p.Illnesses[0].IllName.Contains(filter)
                                                 || string.Concat(p.Addresses.FirstOrDefault(a => a.IsPrimary).City, " ",
                                                            p.Addresses.FirstOrDefault(a => a.IsPrimary).Country, " ",
                                                            p.Addresses.FirstOrDefault(a => a.IsPrimary).ZipCode)
                                                            .Contains(filter));
            patients = OrderPatients(sortOrder, patients);

            var paginatedList = await PaginatedList<PatientDTO>.CreateAsync(_mapper.Map<IQueryable<PatientDTO>>(patients.AsNoTracking()), page ?? 1, size);

            return paginatedList ?? throw new NullReferenceException();
        }

        public async Task Update(PatientDTO patientDto)
        {
            var patient = await _db.Patients.SingleAsync(p => p.Id == patientDto.Id);
            patient = _mapper.Map<Patient>(patientDto);
            _db.Patients.Update(patient);
            _db.SaveChanges();
        }

        private IQueryable<Patient> OrderPatients(string sortOrder, IQueryable<Patient> patients) 
        {
            switch (sortOrder)
            {
                case "nameDesc":
                    patients = patients.OrderByDescending(p => p.Name);
                    break;
                case "email":
                    patients = patients.OrderBy(p => p.Name);
                    break;
                case "emailDesc":
                    patients = patients.OrderByDescending(p => p.Email);
                    break;
                case "DOB":
                    patients = patients.OrderBy(p => p.DayOfBirdth);
                    break;
                case "DOBDesc":
                    patients = patients.OrderByDescending(p => p.DayOfBirdth);
                    break;
                case "phoneNumber":
                    patients = patients.OrderBy(p => p.PhoneNumber);
                    break;
                case "phoneNumberDesc":
                    patients = patients.OrderByDescending(p => p.PhoneNumber);
                    break;
                case "illness":
                    patients = patients.OrderBy(p => p.Illnesses[0].IllName);
                    break;
                case "illnessDesc":
                    patients = patients.OrderByDescending(p => p.Illnesses[0].IllName);
                    break;
                default:
                    patients = patients.OrderBy(p => p.Name);
                    break;
            }
            return patients;
        }
    }
}
