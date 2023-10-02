using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Core.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentModelDto>> GetAppointmentByPatientIdAsync(int patientId);
        Task DeleteAppointment(int appointmentId);
        Task MakeAppointment(MakeAppointmentDto makeAppointment);
    }
}
