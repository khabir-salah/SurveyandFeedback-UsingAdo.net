using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAdo.Core.Domain
{
    public class UnRegistered
    {
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email must contain @gmail.com")]
    public string Email {get; set;}
        
    }
}