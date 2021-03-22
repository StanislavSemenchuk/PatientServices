using PatientService.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace PatientServiceCore.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public bool IsPrimary { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
