using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schoolapp.api.models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public PersonType Type { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
        public int ContactNumber2 { get; set; }
        public int ContactNumber3 { get; set; }
        public Gender Gender { get; set; }
    }

    public enum PersonType
    {
        Administrator = 1,
        SchoolAdmin = 2,
        Principle = 3,
        Teacher = 4,
        Parent = 5
    }
}
