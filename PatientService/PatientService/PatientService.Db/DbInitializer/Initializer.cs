using PatientService.Db.Ef;
using PatientService.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Db.DbInitializer
{
    public class Initializer
    {
        public static void Seed(ApplicationDbContext _db) 
        {
            _db.Database.EnsureCreated();

            //Look for any patient
            if (_db.Patients.Any())
            {
                return; // DB has been seeded
            }

            var patients = new List<Patient>
            {
                new Patient{ Name = "Patient-1", Email = "patient1@example.com", PhoneNumber="010101011", DayOfBirdth = new DateTime(2000, 1, 1)},
                new Patient{ Name = "Patient-2", Email = "patient2@example.com", PhoneNumber="010101012", DayOfBirdth = new DateTime(2000, 2, 2)},
                new Patient{ Name = "Patient-3", Email = "patient3@example.com", PhoneNumber="010101013", DayOfBirdth = new DateTime(2000, 3, 3)},
                new Patient{ Name = "Patient-4", Email = "patient4@example.com", PhoneNumber="010101014", DayOfBirdth = new DateTime(2000, 4, 4)},
                new Patient{ Name = "Patient-5", Email = "patient5@example.com", PhoneNumber="010101015", DayOfBirdth = new DateTime(2000, 5, 5)},
                new Patient{ Name = "Patient-6", Email = "patient6@example.com", PhoneNumber="010101016", DayOfBirdth = new DateTime(2000, 6, 6)}
            };

            var illnesses = new List<Illness>
            {
                new Illness{IllName = "Flu", Type = IllnessType.ColdOrFlu },
                new Illness{IllName = "Cold", Type = IllnessType.ColdOrFlu }
            };

            _db.Patients.AddRange(patients);
            _db.Illnesses.AddRange(illnesses);
            _db.SaveChanges();
        }
    }
}
