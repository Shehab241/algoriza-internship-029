using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Repository.Data;
using Vezeta.core.Repositories.SpecialRepositories;
using Vezeta.Repository;

namespace Vezeta.Repository.SpecialRepositories
{
    internal class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly ApplicationContext _context;

        public BookingRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDoctorId(int doctorId)
        {
            var bookings = await _context.Bookings.Where(b => b.DoctorId == doctorId).ToListAsync();
            return bookings;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPatientId(int patientId)
        {
            var bookings = await _context.Bookings.Where(b => b.PatientId == patientId).ToListAsync();
            return bookings;

        }

        public IQueryable<object> GetTop5Specializations()
        {
            var spec = from specialization in _context.Specializations
                        join doctor in _context.Doctors on specialization.Id equals doctor.SpeciatizationId
                        join booking in _context.Bookings on doctor.Id equals booking.DoctorId
                        group specialization by specialization.Name into groupedSpecializations
                       orderby groupedSpecializations.Count() descending
                       select new
                        {
                            SpecializationName = groupedSpecializations.Key,
                            Count = groupedSpecializations.Count()
                        };

            var Top5 =  spec.Take(5);
            return Top5.Select(item => (new { Name = item.SpecializationName, Count = item.Count }));
        }
        public IQueryable<object> GetTop10Doctors()
        {
            var Doctors = from specialization in _context.Specializations
                         join doctor in _context.Doctors on specialization.Id equals doctor.SpeciatizationId
                         join booking in _context.Bookings on doctor.Id equals booking.DoctorId
                         group specialization by new
                         {
                             DoctorFullName = string.Concat(doctor.FName, doctor.LName),
                             SpecializationName = specialization.Name
                         } into groupedData
                          orderby groupedData.Count() descending
                          select new
                         {
                             FullName = groupedData.Key.DoctorFullName,
                             SpecializationName = groupedData.Key.SpecializationName,
                             Count = groupedData.Count()
                         };

            var Top10 = Doctors.Take(10);
            return Top10.Select(item => (new {name = item.FullName, SpecializationName = item.SpecializationName, Count = item.Count }));
        }
    }
}
