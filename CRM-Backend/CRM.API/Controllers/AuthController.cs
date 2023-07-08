using CRM.Application.Dtos;
using CRM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        
        public AuthController( IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserDto request)
        {
            
            try
            {
                userService.CreatePasswordHash(request.Password);

                return Ok();
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            try
            {
                string token = userService.CreateToken(request);
                return Ok(token);
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }
    }
}
