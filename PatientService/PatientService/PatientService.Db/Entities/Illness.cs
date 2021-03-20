using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientService.Db.Entities
{
    public enum IllnessType 
    {
        Allergies,
        ColdOrFlu,
        Conjunctivitis,
        Diarrhea,
        Headaches,
        Mononucleosis,
        StomachAches,
        Virus
    }
    public class Illness
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IllName { get; set; }
        [Required]
        public IllnessType Type { get; set; }
        public virtual List<Patient> Patients { get; set; }
    }
}
