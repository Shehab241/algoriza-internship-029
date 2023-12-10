using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Repository.Data;
using Vezeta.core.Repositories.SpecialRepositories;
using Vezeta.Repository;

namespace Vezeta.Repository.SpecialRepositories
{
    internal class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationContext _context;

        public PatientRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetNumOfPatients()
        {
            var count = _context.Patients.Select(patient => patient.Id).Distinct().Count();
            return count;
        }
    }
}
