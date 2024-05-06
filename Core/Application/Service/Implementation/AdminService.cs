using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Math.EC.Rfc7748;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Domain;
using SurveyAdo.Core.Domain.Enum;
using SurveyAdo.Infracstructure.Repository;

namespace SurveyAdo.Core.Application.Service.Implementation
{
    public class AdminService : IAdminService
    {
        IRegisteredRepository registeredRepo = new RegisteredRepository();
        IUnRegisteredRepository unRegisteredRepo = new UnRegisteredRepository();
        ISurveyRepository surveyRepo = new SurveyRepository();
        public void ApproveSurvey(string title)
        {
            var approved = surveyRepo.GetSurvey(title);
            if (approved != null)
            {
                approved.Status = Status.Approved;
                surveyRepo.UpdateSurvey(title, approved.Status);
            }
            
        }

        public void DenySurvey(string title)
        {
           var denySurvey = surveyRepo.GetSurvey(title);
            if(denySurvey != null)
            {
                denySurvey.Status = Status.denied;
                surveyRepo.UpdateSurvey(title, denySurvey.Status);
            }
        }

        public ICollection<RegisteredDTO> GetRegisteredUsers()
        {
            var register =  registeredRepo.GetAllUsers();
            var registered = register.Select(x => new RegisteredDTO
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Role = x.Role,
            });
           return registered.ToList();
        }

        public ICollection<UnRegisteredDTO> GetUnRegisteredUsers()
        {
            var unRegister = unRegisteredRepo.GetAllUnRegisteredUsers();
            var unRegistered = unRegister.Select(u => new UnRegisteredDTO
            {
                Email = u.Email,
            });
            return unRegistered.ToList();
        }

        
    }
}