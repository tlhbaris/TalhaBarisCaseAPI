using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalhaBaris.Core.Models;
using TalhaBaris.Core.Repositories;

namespace TalhaBaris.Repository.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly AppDbContext _context;
        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<DoctorModel>> GetAllDoctorsAsync()
        {
            try
            {
                return await _context.Doctors.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
