using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Repository
{
    public interface IFeedbackRepository
    {
        Feedback AddFeedback( Feedback feedback);
        ICollection<Feedback> GetFeedbacks();
        ICollection<Feedback> GetFeedback(string email);

    }
}