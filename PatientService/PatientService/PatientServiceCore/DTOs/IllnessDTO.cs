using PatientService.Db.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientServiceCore.DTOs
{
    public class IllnessDTO
    {
        public int Id { get; set; }
        [Required]
        public string IllName { get; set; }
        [Required]
        public IllnessType Type { get; set; }
        public virtual List<int> PatientsIds { get; set; }
    }
}
