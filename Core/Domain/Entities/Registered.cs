using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mysqlx;

namespace SurveyAdo.Core.Domain
{
    public class Registered
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email must contain @gmail.com")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}