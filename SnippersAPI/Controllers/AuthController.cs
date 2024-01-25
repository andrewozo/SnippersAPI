using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnippersAPI.Data;
using SnippersAPI.DTOS.User;

namespace SnippersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(new User
            {
                Email = request.Email,
                
            }, request.Password);


            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Email, request.Password);


            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }



    }
}
