using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;
using TalhaBaris.Core.Repositories;
using TalhaBaris.Core.Services;

namespace TalhaBaris.Repository.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMailService _mailService;

        public AppointmentRepository(AppDbContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            try
            {
                var appointment = await _context.Appointments.SingleOrDefaultAsync(x => x.Id == appointmentId);
                if (appointment != null)
                {
                    appointment.Status = false;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Böyle bir kullanıcı bulunamadı.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<AppointmentModel>> GetAppointmentByPatientIdAsync(int patientId)
        {
            try
            {
                var appointments = await _context.Appointments.Where(x => x.PatientId == patientId && x.Status == true).Include(x => x.Doctor).ToListAsync();
                if (appointments.Count == 0)
                {
                    throw new Exception("Böyle bir randevu bulunamadı");
                }
                return appointments;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task MakeAppointment(MakeAppointmentDto makeAppointment)
        {
            try
            {
                int minute = makeAppointment.AppointmentDateTime.Minute;
                if (!(minute == 00 || minute == 15 || minute == 30 || minute == 45))
                {
                    throw new Exception("Hatalı saat seçimi yaptınız");
                }

                PatientModel patientModel = new();
                var patient = await _context.Patients.Where(x => x.Email == makeAppointment.patientModel.Email).FirstOrDefaultAsync();
                int patientId;
                if (patient == null)
                {

                    patientModel.Name = makeAppointment.patientModel.Name;
                    patientModel.Surname = makeAppointment.patientModel.Surname;
                    patientModel.Email = makeAppointment.patientModel.Email;
                    _context.Patients.Add(patientModel);
                    _context.SaveChanges();
                    patientId = patientModel.Id;
                }
                else
                {
                    patientId = patient.Id;
                }

                var doctorCheckDate = await _context.Appointments.Where(x => x.DoctorId == makeAppointment.DoctorId).Where(x => x.AppointmentDate == makeAppointment.AppointmentDateTime).FirstOrDefaultAsync();
                if (doctorCheckDate != null)
                {
                    throw new Exception("Doktorun seçili tarihte başka randevusu bulunmaktadır.");
                }
                var patientCheckDate = await _context.Appointments.Where(x => x.PatientId == patientId).Where(x => x.AppointmentDate == makeAppointment.AppointmentDateTime).FirstOrDefaultAsync();
                if (patientCheckDate != null)
                {
                    throw new Exception("Hastanın seçili tarihte başka randevusu bulunmaktadır.");
                }

                AppointmentModel appointmentModel = new AppointmentModel();
                appointmentModel.AppointmentDate = makeAppointment.AppointmentDateTime;
                appointmentModel.PatientId = patientId;
                appointmentModel.DoctorId = makeAppointment.DoctorId;
                _context.Add(appointmentModel);
                await _context.SaveChangesAsync();

                SendEmailModel sendEmailModel = new();
                sendEmailModel.To = makeAppointment.patientModel.Email;
                sendEmailModel.Body = $"Sayın {makeAppointment.patientModel.Name} {makeAppointment.patientModel.Surname} {makeAppointment.AppointmentDateTime.ToString("dd.MM.yyyy HH:mm")} tarihinde randevunuz oluşturulmuştur.";
                sendEmailModel.Subject = "Randevunuz Hk.";

                await _mailService.SendMessageAsync(sendEmailModel.To, sendEmailModel.Subject, sendEmailModel.Body);

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
