using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.Models;

namespace TalhaBaris.Core.Repositories
{
    public interface IDoctorRepository
    {

        Task<List<DoctorModel>> GetAllDoctorsAsync();
    }
}
