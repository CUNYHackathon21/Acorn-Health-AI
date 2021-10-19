using AcornHealthAIBackend.Models;
using AcornHealthAIBackend.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AcornHealthAIBackend.Controllers {
    [EnableCors("TCAPOLICY")]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase {
        internal AuthenticationService AuthenticationService { get; }

        public AuthenticationController(AuthenticationService authService) {
            AuthenticationService = authService;
        }

        [HttpPost("login")]
        public AuthenticationResponse Login(LoginModel login) {
            if (login is null || string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
                return new() { Success = false };

            // Validate authentication
            bool valid = AuthenticationService.Login(login.Email, login.Password, out var token);
            if (!valid) {
                // Invalid login
                return new() { Success = false };
            }

            return new() { 
                Success = true,
                Token = token
            };
        }

        public class LoginModel {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
