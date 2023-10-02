using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalhaBaris.Cache;
using TalhaBaris.Core.Models;
using TalhaBaris.Core.Repositories;


namespace TalhaBaris.Repository.Repositories
{
    public class DoctorRepositoryWithCacheDecarotar : IDoctorRepository
    {

        private const string doctorKey = "doctorCaches";
        private readonly IDoctorRepository _doctorRepository;
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;


        public DoctorRepositoryWithCacheDecarotar(IDoctorRepository doctorRepository, RedisService redisService)
        {
            _doctorRepository = doctorRepository;
            _redisService = redisService;
            _cacheRepository= _redisService.GetDb(2);
        }

        private async Task<List<DoctorModel>> LoadToCacheFromDbAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();

            doctors.ForEach(d =>
            {
                _cacheRepository.HashSetAsync(doctorKey, d.Id, JsonSerializer.Serialize(d));
            });

            return doctors;
        }

        public async Task<List<DoctorModel>> GetAllDoctorsAsync()
        {
            if (!await _cacheRepository.KeyExistsAsync(doctorKey))
            {
                return await  LoadToCacheFromDbAsync();
            }

            var doctors = new List<DoctorModel>();
            var cacheDoctors = await _cacheRepository.HashGetAllAsync(doctorKey);

            foreach (var item in cacheDoctors.ToList())
            {
                var doctor = JsonSerializer.Deserialize<DoctorModel>(item.Value);
                doctors.Add(doctor);
            }

            return doctors;
        }
    }
}
