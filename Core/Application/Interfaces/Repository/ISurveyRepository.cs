using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain;
using SurveyAdo.Core.Domain.Enum;

namespace SurveyAdo.Core.Application.Interfaces.Repository
{
    public interface ISurveyRepository
    {
        public Survey AddSurvey(Survey survey);
        public ICollection<Survey> GetAllSurvey();
        public ICollection<Survey> GetSurveyByUser(string email);
        bool IsDelete(string title);
        Survey GetSurvey(string title);
        bool UpdateSurvey(string title, Status status);

    }
}