using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Domain;
using SurveyAdo.Core.Domain.Enum;
using SurveyAdo.Infracstructure.Repository;

namespace SurveyAdo.Core.Application.Service.Implementation
{
    public class SurveyService : ISurveyService
    {
        ISurveyRepository surveyRepo = new SurveyRepository();
        IRegisteredService registeredService= new RegisteredService();

        public SurveyDTO CreatSurvey(RequestModelSurveyDTO request)
        {
            var checkIfTitleExist = isTitleExist(request.Title);
            if(checkIfTitleExist)
            {
                return null;
            }
            var survey = new Survey
            {
                Title = request.Title,
                UserEmail = registeredService.GetCurrentUser().Email,
                Status = Status.pending,
                Question = request.Question,
            };
            surveyRepo.AddSurvey(survey);
            return new SurveyDTO
            {
                UserEmail = registeredService.GetCurrentUser().Email,
                Status = Status.pending,
                Title = request.Title,
                Question = request.Question,
            };
        }

        private bool isTitleExist(string title)
        {
            var checkTitle = surveyRepo.GetSurvey(title);
            if(checkTitle != null)
            {
                return true;
            }
            return false;
        }

        public ICollection<SurveyDTO> GetAllDeniedSurvey()
        {
            var denied = new List<SurveyDTO>();
        var checkDenied = surveyRepo.GetAllSurvey().Where(d => d.Status == Status.denied);
        foreach (var deny in checkDenied)
        {
            var denyDto = new SurveyDTO
            {
                UserEmail = deny.UserEmail,
                Question = deny.Question,
                Title = deny.Title,
            };
            denied.Add(denyDto);
        }
            return denied;
        }

        public ICollection<SurveyDTO> GetAllPendingSurvey()
        {
            var pending = new List<SurveyDTO>();
        var checkPending = surveyRepo.GetAllSurvey().Where(d => d.Status == Status.pending);
        foreach (var pend in checkPending)
        {
            var pendDto = new SurveyDTO
            {
                UserEmail = pend.UserEmail,
                Question = pend.Question,
                Title = pend.Title,
            };
            pending.Add(pendDto);
        }
            return pending;
        }

        public ICollection<SurveyDTO> GetApprovedSurveyByClient(string email)
        {
            var approved = new List<SurveyDTO>();
            var checkApproved = surveyRepo.GetSurveyByUser(email).Where(d => d.Status == Status.Approved);
            foreach (var approve in checkApproved)
        {
            var approvedDto = new SurveyDTO
            {
                UserEmail = approve.UserEmail,
                Question = approve.Question,
                Title = approve.Title,
            };
            approved.Add(approvedDto);
        }
            return approved;
        }

        public ICollection<SurveyDTO> GetDeniedSurveyByClient(string email)
        {
            var denied = new List<SurveyDTO>();
            var checkDenied = surveyRepo.GetSurveyByUser(email).Where(d => d.Status == Status.denied);
            foreach (var deny in checkDenied)
        {
            var denyDto = new SurveyDTO
            {
                UserEmail = deny.UserEmail,
                Question = deny.Question,
                Title = deny.Title,
            };
            denied.Add(denyDto);
        }
            return denied;
        }

        public ICollection<SurveyDTO> GetPendingSurveyByClient(string email)
        {
            var pending = new List<SurveyDTO>();
            var checkPending = surveyRepo.GetSurveyByUser(email).Where(d => d.Status == Status.pending);
            foreach (var pend in checkPending)
        {
            var pendDto = new SurveyDTO
            {
                UserEmail = pend.UserEmail,
                Question = pend.Question,
                Title = pend.Title,
            };
            pending.Add(pendDto);
        }
            return pending;
        }

        public SurveyDTO GetSurvey(string title)
        {
            var surveyTitle = surveyRepo.GetSurvey(title);
            return new SurveyDTO
            {
                UserEmail = surveyTitle.UserEmail,
                Title = surveyTitle.Title,
                Status = Status.Approved,
                Question = surveyTitle.Question,
            };
        }

        public ICollection<SurveyDTO> GetSurveysByUser()
        {
            var userSurvey = surveyRepo.GetAllSurvey();
            var surveyDto = userSurvey.Select(u => new SurveyDTO
            {
                Title = u.Title,
                Status = u.Status,
                Question = u.Question,
                UserEmail = u.UserEmail,
            });
            return surveyDto.ToList();
        }

        public bool IsDelete(string title)
        {
            throw new NotImplementedException();
        }

        public ICollection<SurveyDTO> ViewAllApprovedSurvey()
        {
             var approved = new List<SurveyDTO>();
        var checkApproved = surveyRepo.GetAllSurvey().Where(d => d.Status == Status.Approved);
        foreach (var approve in checkApproved)
        {
            var approvedDto = new SurveyDTO
            {
                UserEmail = approve.UserEmail,
                Question = approve.Question,
                Title = approve.Title,
            };
            approved.Add(approvedDto);
        }
            return approved;
        }

        
    }
}