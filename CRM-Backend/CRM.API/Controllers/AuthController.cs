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
        private readonly ILoginService loginService;

        public AuthController(ILoginService loginService, IUserService userService)
        {
            this.loginService = loginService;
            this.userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserDto request)
        {

            try
            {
                await userService.AddAsync(request);

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
                
                var token = await loginService.Login(request);

                return Ok(token);
            }
            catch (Exception e)
            {

                return Problem($"Hata !!! {e.Message} {e.StackTrace}");
            }
        }
    }
}
