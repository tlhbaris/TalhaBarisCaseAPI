using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalhaBaris.Core.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool Status { get; set; }
        public DoctorModel Doctor { get; set; }
        public PatientModel Patient { get; set; }

    }
}
