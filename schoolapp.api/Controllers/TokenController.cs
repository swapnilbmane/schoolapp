using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using schoolapp.api.models;

namespace schoolapp.api.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;
        public TokenController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]        
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            IActionResult response = Unauthorized();
            
            if (ModelState.IsValid)
            {
                Person user = Authenticate(loginViewModel);

                if (user != null)
                {
                    var tokenString = BuildToken(user);
                    response = Ok(new { token = tokenString });
                }
            }

            return response;
        }

        private string BuildToken(Person user)
        {
            var claims = new[] {
                //new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                                _configuration["Jwt:Issuer"],
                                _configuration["Jwt:Issuer"],
                                claims,
                                expires: DateTime.Now.AddHours(3),
                                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Person Authenticate(LoginViewModel loginViewModel)
        {
            string hashedPassword = loginViewModel.Password; //todo:encode password
            Person user = _context.Persons.FirstOrDefault(item => item.Email == loginViewModel.Email && 
                                                                  item.Password == hashedPassword);
            
            return user;
        }

        //private string GetHashedPassword(string password)
        //{
            //todo:encode passsword
            // var data = Encoding.ASCII.GetBytes(password);
            // var sha1 = new SHA1CryptoServiceProvider();
            // var sha1data = sha1.ComputeHash(data);
            // string hashedPassword = ASCIIEncoding.GetString(sha1data);
            // return sha1data;
        //}
    }
}