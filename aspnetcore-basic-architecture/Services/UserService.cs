using AspnetCoreBasicArchitecture.Infrastructure.Extensions;
using AspnetCoreBasicArchitecture.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspnetCoreBasicArchitecture.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<UserManagerResponseViewModel> RegisterUserAsync(UserRegisterViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("Register model is not null");
            }
            var user = new IdentityUser
            {
                Email = viewModel.Email,
                UserName = viewModel.UserName
            };
            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                return new UserManagerResponseViewModel
                {
                    Message = "Your account has been created successfully",
                    IsSuccess = true
                };
            }

            return new UserManagerResponseViewModel
            {
                Message = "Your account did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }


        public async Task<UserManagerResponseViewModel> LoginUserAsync(UserLoginViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user == null)
            {
                return new UserManagerResponseViewModel
                {
                    Message = "There is no user with Email adress",
                    IsSuccess = false
                };

            }
            var result = await _userManager.CheckPasswordAsync(user, viewModel.Password);

            if (!result)
            {
                return new UserManagerResponseViewModel
                {
                    Message = "",
                    IsSuccess = false
                };
            }
            var claims = new[]
            {
                new Claim("",viewModel.Email),new Claim(ClaimTypes.NameIdentifier,user.Id)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration.JwtTokenConfiguration().ValidIssuer,
                audience: _configuration.JwtTokenConfiguration().ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_configuration.JwtTokenConfiguration().ConvertBytes()), SecurityAlgorithms.HmacSha256));
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponseViewModel
            {
                Message = tokenString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
        }


    }
}
