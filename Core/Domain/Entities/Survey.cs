using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain.Enum;

namespace SurveyAdo.Core.Domain
{
    public class Survey
    {
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email must contain @gmail.com")]
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public List<string> Question { get; set; }
    }
}