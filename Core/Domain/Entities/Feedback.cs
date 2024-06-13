using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAdo.Core.Domain
{
    public class Feedback
    {
        string name = Guid.NewGuid().ToString();
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email must contain @gmail.com")]
        public string UserEmail {get; set;}
        [Display(Name ="Survey Title")]
    public string SurveyTitle {get; set;}
    
    // public string question {get; set;}
    // public Survey Question {get; set;}
    [Column("Response")]
        public List<string> Answers {get; set;}

    }
}