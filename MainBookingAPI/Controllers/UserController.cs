using Services.RepositoryPattern.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Services.ViewModels;

namespace MainBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator; 
       
        public UserController(IUserService userService, IConfiguration configuration,IMediator MediatR)
        {
            _userService = userService;
            _configuration = configuration;
            _mediator = MediatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetListUser()
        {
            var quary = new Queries.GetAllUserQuery();
            var result = await _mediator.Send(quary); 
            return Ok(await _userService.GetUserList());

        }
        [Route("/Login")]
        [HttpPost]
       
        public async Task<IActionResult> Login(LoginModel log)
        {
            bool IsLogin = await _userService.UserLoginAsync(log);

            if (IsLogin == true)    //User was found
            {
                return Ok("Ok");
            }
            else    //User was not found
            {
                return NotFound("Not Fount User");
            }

        }
    }
}
        