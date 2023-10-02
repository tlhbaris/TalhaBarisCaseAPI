using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;
using TalhaBaris.Core.Services;

namespace TalhaBarisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMailService _mail;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetAppointmentByPatientId(int patientId)
        {
            try
            {
                var appointment = await _appointmentService.GetAppointmentByPatientIdAsync(patientId);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{ex.Message}");
            }
        }

        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            try
            {
                await _appointmentService.DeleteAppointment(appointmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> MakeAppointment(MakeAppointmentDto makeAppointment)
        {
            try
            {
                await _appointmentService.MakeAppointment(makeAppointment);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{ex.Message}");
            }
             
        }


    }
}
