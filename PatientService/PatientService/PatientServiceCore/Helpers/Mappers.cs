using AutoMapper;
using PatientService.Db.Entities;
using PatientServiceCore.DTOs;

namespace PatientServiceCore.Helpers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
        }
    }
}
