using AutoMapper;
using PatientService.Db.Entities;
using PatientServiceCore.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PatientServiceCore.Helpers.ValueResolvers
{
    class IllnessesResolver : IValueResolver<Illness, IllnessDTO, List<int>>
    {
        public List<int> Resolve(Illness source, IllnessDTO destination, List<int> destMember, ResolutionContext context)
        {
            return source.Patients.Select(p => p.Id).ToList();
        }
    }
}
