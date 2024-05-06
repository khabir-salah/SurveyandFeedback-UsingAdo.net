using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain.Enum;

namespace SurveyAdo.Core.Domain
{
    public class Survey
    {
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public List<string> Question { get; set; }
    }
}