using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeta.core.Repositories.SpecialRepositories;

namespace Vezeta.core.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        
       IGenericRepository<Doctor> DoctorRepo { get;  }
       IBookingRepository BookingRepo { get;  }
       IPatientRepository PatientRepo { get; }
       IGenericRepository<Discount> DiscountRepo { get; }
        Task<int> Complete();
    }
}
