using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.DTOs;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Core.Services
{
    public interface IDoctorService
    {
        Task<List<DoctorModelDto>> GetAllDoctorsAsync();
    }
}
