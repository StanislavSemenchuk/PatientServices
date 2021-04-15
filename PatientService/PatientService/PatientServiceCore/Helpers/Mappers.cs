using AutoMapper;
using PatientService.Db.Entities;
using PatientServiceCore.DTOs;
using PatientServiceCore.Helpers.ValueResolvers;

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

            CreateMap<Illness, IllnessDTO>()
                .ForMember(d => d.PatientsIds, o => o.MapFrom<IllnessesResolver>());

            CreateMap<IllnessDTO, Illness>();
        }
    }
}
