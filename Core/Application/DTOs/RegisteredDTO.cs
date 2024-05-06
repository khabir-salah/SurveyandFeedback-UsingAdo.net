using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.DTOs
{
    public class RegisteredDTO
    {
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    
    public class RequestModelRegisteredDTO
    {
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RequestLogInDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}