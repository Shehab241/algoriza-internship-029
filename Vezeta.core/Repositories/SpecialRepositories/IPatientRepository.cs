using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeta.core.Repositories.SpecialRepositories
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {

        Task<int> GetNumOfPatients();
    }
}
