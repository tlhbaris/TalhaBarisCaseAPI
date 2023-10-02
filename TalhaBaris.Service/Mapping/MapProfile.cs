using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<DoctorModel, DoctorModelDto>();
            CreateMap<AppointmentModel, AppointmentModelDto>();
        }

    }
}
