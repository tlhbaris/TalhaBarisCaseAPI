using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Repository.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentModel>
    {
        public void Configure(EntityTypeBuilder<AppointmentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.DoctorId, x.PatientId, x.AppointmentDate }); //Aynı doktor, aynı hasta, aynı tarih ve aynı saatte birden fazla randevu kaydedilmesinin önüne geçmek için.
            builder.Property(x => x.DoctorId).IsRequired();
            builder.Property(x => x.PatientId).IsRequired();
            builder.Property(x => x.AppointmentDate).IsRequired();



        }
    }
}
