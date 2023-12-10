using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;

namespace Vezeeta.Core.Service
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(User user, UserManager<User> userManager);

    }
}
