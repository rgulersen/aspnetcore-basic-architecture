using AspnetCoreBasicArchitecture.ViewModel;
using Microsoft.AspNetCore.Identity;
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

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<UserManagerResponseViewModel> RegisterUserAsync(UserRegisterViewModel viewModel)
        {
            if (viewModel == null) throw new NullReferenceException("Register model is not null");
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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for authnetication"));
            var token = new JwtSecurityToken(
                issuer: "demo", 
                audience: "demo",
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
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
