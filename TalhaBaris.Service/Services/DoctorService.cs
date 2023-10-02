using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;
using TalhaBaris.Core.Repositories;
using TalhaBaris.Core.Services;

namespace TalhaBaris.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository  doctorRepository, IMapper mapper)
        {
            _doctorRepository= doctorRepository;
            _mapper= mapper;
        }

        public async Task<List<DoctorModelDto>> GetAllDoctorsAsync()
        {
           var doctors = await  _doctorRepository.GetAllDoctorsAsync();
           var doctorsDto = _mapper.Map<List<DoctorModelDto>>(doctors.ToList());
           return doctorsDto;
        }
    }
}
