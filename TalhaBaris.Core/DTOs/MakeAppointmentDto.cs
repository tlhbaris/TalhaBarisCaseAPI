using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Core.DTOs
{
    public class MakeAppointmentDto
    {
        public PatientModelDto patientModel { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        

    }
}
