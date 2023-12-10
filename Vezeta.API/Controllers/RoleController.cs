using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.APIs.DTOS;
using Vezeeta.Core.Entities;

namespace Vezeeta.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController( RoleManager<IdentityRole> roleManager ,UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromQuery] RoleDto role)
        {
            var Role = new IdentityRole()
            {
                Name=role.RoleName
            };

            if (role == null || string.IsNullOrWhiteSpace(Role.Name))
            {
                return BadRequest("Role name cannot be empty");
            }

            var roleExist = await _roleManager.RoleExistsAsync(Role.Name);
            if (roleExist)
            {
                return StatusCode(409, "Role already exists");
            }

            var result = await _roleManager.CreateAsync(Role);
            if (result.Succeeded)
            {
                return Ok($"Role {Role.Name} created successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole(string userName, [FromQuery] RoleDto role)
        {
            var allowedRoles = new List<string> { "Patient", "Doctor", "Admin","patient","doctor","admin"};

            
            if (!allowedRoles.Contains(role.RoleName))
            {
                return BadRequest();
            }
            var Role = new IdentityRole()
            {
                Name = role.RoleName
            };
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            //var roleName = role.ToString();
            var roleExist = await _roleManager.RoleExistsAsync(Role.Name);

            if (!roleExist)
            {
                return BadRequest("Role not found");
            }

            var result = await _userManager.AddToRoleAsync(user, Role.Name);

            if (result.Succeeded)
            {
                return Ok($"User {user.UserName} assigned to role {Role.Name} successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

       
    }

}


