using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Domain;
using SurveyAdo.Infracstructure.Repository;

namespace SurveyAdo.Core.Application.Service.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        IFeedbackRepository feedbackRepo = new FeedbackRepository();
        ISurveyService surveyService= new SurveyService();
        public List<FeedbackDTO> GetFeedbacks(string title)
        {
            var getFeedback = new List<FeedbackDTO>();
            var feedback = feedbackRepo.GetFeedback(title);
            foreach(var response in feedback)
            {
                var feedbackDTO = new FeedbackDTO
                {
                    UserEmail = response.UserEmail,
                    Answers = response.Answers,
                    SurveyTitle = response.SurveyTitle,
                };
                getFeedback.Add(feedbackDTO);
            }
            return getFeedback;
        }

        public void GiveFeedback(RequestModelFeedbackDTO request)
        {
            var isFeedbackExist = IsFeedbackExist(request.SurveyTitle, request.UserEmail);
            if (isFeedbackExist)
            {
                return;
            }
            var feedback = surveyService.GetSurvey(request.SurveyTitle);
            request.Answers = new List<string>();
            foreach (var item in feedback.Question)
            {
                Console.WriteLine(item);
                var respond = Console.ReadLine();
                request.Answers.Add(respond);
            }
            var feedbacks = new Feedback
            {
                UserEmail = request.UserEmail,
                Answers = request.Answers,
                SurveyTitle = request.SurveyTitle,
            };
            feedbackRepo.AddFeedback(feedbacks);
        }

        private bool IsFeedbackExist(string title, string email)
        {
            var feedback = feedbackRepo.GetFeedbacks().Where(f => f.SurveyTitle == title && f.UserEmail == email).Any();
            if(feedback)
            { 
                return true;
            }
            return false;
        }
    }
}