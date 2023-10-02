using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using TalhaBaris.Cache;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Services;

namespace TalhaBarisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService,RedisService redisService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDoctors()
        {
            try
            {
                var doctorsDto = await _doctorService.GetAllDoctorsAsync();
                //return Ok(CustomResponseDto<List<DoctorModelDto>>.Success(200, doctorsDto));
                return Ok(doctorsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{ex.Message}");
            }
            
        }
    }
}
