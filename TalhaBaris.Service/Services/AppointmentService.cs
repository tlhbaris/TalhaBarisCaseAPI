using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;
using TalhaBaris.Core.Repositories;
using TalhaBaris.Core.Services;

namespace TalhaBaris.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public AppointmentService(IAppointmentRepository appointmentRepository,IMapper mapper, IMailService mailService)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            await _appointmentRepository.DeleteAppointment(appointmentId);
        }

        public async Task<List<AppointmentModelDto>> GetAppointmentByPatientIdAsync(int patientsId)
        {
            var appointment = await _appointmentRepository.GetAppointmentByPatientIdAsync(patientsId);
            var appointmentDto = _mapper.Map<List<AppointmentModelDto>>(appointment.ToList());
            return appointmentDto;
        }

        public async Task MakeAppointment(MakeAppointmentDto makeAppointment)
        {
            await _appointmentRepository.MakeAppointment(makeAppointment);
        }
    }
}
