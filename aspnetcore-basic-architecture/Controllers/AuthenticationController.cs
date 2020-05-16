using AspnetCoreBasicArchitecture.Services;
using AspnetCoreBasicArchitecture.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreBasicArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody]UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(userRegisterViewModel);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

            }
            var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return BadRequest(message);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync([FromBody]UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(userLoginViewModel);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return BadRequest(message);
        }
    }
}
