using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Core.Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<AppointmentModel>> GetAppointmentByPatientIdAsync(int patientId);
        Task DeleteAppointment(int appointmentId);
        Task MakeAppointment(MakeAppointmentDto makeAppointment);

    }
}
