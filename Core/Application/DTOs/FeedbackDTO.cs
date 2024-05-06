using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAdo.Core.Application.DTOs
{
    public class FeedbackDTO
    {
         public string UserEmail {get; set;}
    public string SurveyTitle {get; set;}
    public List<string> Answers {get; set;}

    }


    public class RequestModelFeedbackDTO
    {
         public string UserEmail {get; set;}
    public string SurveyTitle {get; set;}

    public List<string> Answers {get; set;}

    }
}