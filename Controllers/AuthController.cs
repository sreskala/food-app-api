using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using food_tracker_api.Data;
using food_tracker_api.Models;
using food_tracker_api.Dtos.User;

namespace food_tracker_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDTO request) {
            var response = await _authRepo.Login(request.Username, request.Password);

            if (!response.Success) {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDTO request) {
            var response = await _authRepo.Register(
                new User {Username = request.Username}, request.Password
            );

            if (!response.Success) {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}