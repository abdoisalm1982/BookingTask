using DataAccessLayer.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.Linq;
using  Services.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Services.RepositoryPattern.UserLogin
{
    public class UserService : IUserService
    {
        private readonly BookingDbContext _BookingDbContext;
        private readonly IMapper _mapper;
   
        public UserService(BookingDbContext cFCDbContext, IMapper mapper)
        {
            _BookingDbContext = cFCDbContext;
            _mapper = mapper;
            
        }
 
        public async Task<List<LoginModel>> GetUserList()
        {
            try
            {
                var user = await _BookingDbContext.Users.ToListAsync();
                return _mapper.Map<List<LoginModel>>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region User Login
        public async Task<bool> UserLoginAsync(LoginModel loginModel)
        {
            try
            {
                var response = await _BookingDbContext.Users.Where(c => c.Email.Equals(loginModel.UserEmail) && c.Password.Equals(loginModel.UserPassword)).AnyAsync();
                if (response is true) return true; else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
