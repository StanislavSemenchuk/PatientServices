using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientServiceCore.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DayOfBirdth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public virtual List<AddressDTO> Addresses { get; set; }
        public virtual List<IllnessDTO> Illnesses { get; set; }
    }
}
