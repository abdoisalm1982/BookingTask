using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MainBookingAPI.Queries;
using  Services.ViewModels;
using System.Threading;
using Services.RepositoryPattern.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;




namespace MainBookingAPI.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUserQuery, List<LoginModel>>
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
       // private readonly IMediator _mediator;
        public GetAllUsersHandler(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
            
        }
        public async Task<List<LoginModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserList();
        }
    }
}
