using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Service
{
    public interface IAdminService
    {
        void ApproveSurvey(string title);
        void DenySurvey(string title);
        ICollection<RegisteredDTO> GetRegisteredUsers();
        ICollection<UnRegisteredDTO> GetUnRegisteredUsers();
    }
}