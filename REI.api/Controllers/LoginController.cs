using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REIFinal.Core.Data;
using REIFinal.Core.Dto;
using REIFinal.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [Route("Auth")]
        public IActionResult GetLoginToken([FromBody] Users user)
        {
            var token = loginService.GetLoginToken(user);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }

        [Route("EmailVerification")]
        [HttpPost]
        public string getBookById([FromBody] Users user)
        {
            return loginService.EmailVerification(user);
        }
        [Route("NewPassword")]
        [HttpPost]
        public string SetNewPassword([FromBody] SetNewPassword setNewPassword)
        {
            return loginService.SetNewPassword(setNewPassword);
        }
    }
}
