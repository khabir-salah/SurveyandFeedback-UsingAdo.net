using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAdo.Core.Domain
{
    public class Feedback
    {
        public string UserEmail {get; set;}
    public string SurveyTitle {get; set;}
    
    // public string question {get; set;}
    // public Survey Question {get; set;}
    public List<string> Answers {get; set;}

    }
}