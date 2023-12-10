using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Repository.Data;
using Vezeta.core.Repositories;
using Vezeta.core.Repositories.SpecialRepositories;
using Vezeta.Repository.SpecialRepositories;

namespace Vezeta.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext _context;

        public IGenericRepository<Doctor> DoctorRepo { get; private set; }
        public IPatientRepository PatientRepo { get; private set; }
        public IGenericRepository<Discount> DiscountRepo { get; private set; }

        public IBookingRepository BookingRepo { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            DoctorRepo = new GenericRepository<Doctor>(context);
            BookingRepo = new BookingRepository(context);
            PatientRepo = new PatientRepository(context);
            DiscountRepo = new GenericRepository<Discount>(context);
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
