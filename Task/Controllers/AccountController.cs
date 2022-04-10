
using Core.InterFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.Identity;
using System.Security.Claims;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser>singInManager , ITokenService tokenService )
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _tokenService = tokenService;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return new UserDto
            {
                Email = user.Email.ToString(),
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName,
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null) return Unauthorized();
            var result = await _singInManager.CheckPasswordSignInAsync(user,login.Password,false);
            if (!result.Succeeded) return Unauthorized();
            return new UserDto
            {
                Email = user.Email.ToString(),
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName,
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            var user = new AppUser
            {
                UserName = register.Email,
                Email = register.Email,
                DisplayName=register.UserName

            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded) return BadRequest(ModelState);
            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                UserName = user.DisplayName,
            };
        }
    }
}
