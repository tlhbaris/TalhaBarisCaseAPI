using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Repository.Seeds
{
    public class DoctorSeed : IEntityTypeConfiguration<DoctorModel>
    {
        public void Configure(EntityTypeBuilder<DoctorModel> builder)
        {
            builder.HasData(new DoctorModel
            {

                Id = 1,
                Name = "Tony",
                Surname = "Soprano",
                Specialization = "Psikoloji"
            },
            new DoctorModel
            {
                Id = 2,
                Name = "Tyrion",
                Surname = "Lannister",
                Specialization = "Beyin ve Sinir Cerrahisi"
            },
            new DoctorModel
            {
                Id = 3,
                Name = "John",
                Surname = "Locke",
                Specialization = "Kulak Burun Boğaz"
            },
            new DoctorModel
            {
                Id = 4,
                Name = "Walter",
                Surname = "White",
                Specialization = "Nöroloji"
            },
            new DoctorModel
            {
                Id = 5,
                Name = "Dexter",
                Surname = "Morgan",
                Specialization = "Genel Cerrahi"
            }

            );
        }
    }
}
