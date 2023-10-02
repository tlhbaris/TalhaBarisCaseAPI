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
                Name = "Talha",
                Surname = "Baris",
                Specialization = "KBB"
            },
            new DoctorModel
            {
                Id = 2,
                Name = "cemal",
                Surname = "Baris",
                Specialization = "noroloji"
            },
            new DoctorModel
            {
                Id = 3,
                Name = "mehmet",
                Surname = "Baris",
                Specialization = "göz"
            }

            );
        }
    }
}
