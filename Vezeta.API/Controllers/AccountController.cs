using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Vezeeta.APIs.DTOS;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Service;

namespace Vezeeta.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController
            (UserManager<User> userManager,
            SignInManager<User> signInManager
            , ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
         [HttpPost("register")]
        public async Task<IActionResult> SignUp( RegisterDto registerDto)
        {

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);

            if (existingUser != null)
            {

                return BadRequest(new { Message = "The e-mail is already taken." });
            }
            var user = new User()
                { 
                    Email=registerDto.Email,
                    UserName=registerDto.UserName,         
                };
                var result=await _userManager.CreateAsync(user,registerDto.Password);
                if (!result.Succeeded) {

                    return BadRequest(new {Message="faild to create user"});
                }
                var userdto= new UserDto {
                    Displayname=user.UserName, 
                    Email=user.Email,
                    Token= await _tokenService.CreateTokenAsync(user, _userManager),
                
                };

                return Ok(userdto);
           
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromQuery] LoginDto loginDto)
        {

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return Ok(new User()
            {
                UserName = user.UserName,
                Email = user.Email,

            });
        }
      

    }
}
