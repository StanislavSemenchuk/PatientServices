using AutoMapper;
using PatientService.Db.Entities;
using PatientServiceCore.DTOs;
using System.Linq;

namespace PatientServiceCore.Helpers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<Illness, IllnessDTO>();
            CreateMap<IllnessDTO, Illness>();
        }
    }
}
