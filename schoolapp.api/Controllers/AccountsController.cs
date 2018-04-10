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
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // POST api/accounts
        [AllowAnonymous]
        [HttpPost]
        public int Post([FromBody]RegisterViewModel model)
        {
            int userId = -1;
            if (ModelState.IsValid)
            {
                if(model.Password == model.ConfirmPassword)
                {
                    Person person = new Person() {
                        Email = model.Email,
                        Password = model.Password,
                        Type = model.Type
                    };
                    _context.Add<Person>(person);
                    _context.SaveChanges();
                    return person.PersonId;
                }
            }

            return userId;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
