using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeta.core.Repositories.SpecialRepositories
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {

        Task<IEnumerable<Booking>> GetBookingsByPatientId(int patientId);
        Task<IEnumerable<Booking>> GetBookingsByDoctorId(int doctorId);
        IQueryable<object> GetTop5Specializations();
        IQueryable<object> GetTop10Doctors();

    }
}
