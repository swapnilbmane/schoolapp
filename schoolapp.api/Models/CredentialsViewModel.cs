using System;
using Microsoft.EntityFrameworkCore;

namespace schoolapp.api.models
{
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}