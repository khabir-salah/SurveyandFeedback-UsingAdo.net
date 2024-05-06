using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain;
using SurveyAdo.Core.Domain.Enum;

namespace SurveyAdo.Core.Application.DTOs
{
    public class SurveyDTO
    {
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public List<string> Question { get; set; }

        // public static explicit operator SurveyDTO(Survey v)
        // {
        //     throw new NotImplementedException();
        // }
    }

     public class RequestModelSurveyDTO
    {
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public List<string> Question { get; set; }
    }
}