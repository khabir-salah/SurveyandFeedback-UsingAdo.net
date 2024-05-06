using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Service
{
    public interface IUnRegisteredService
    {
        public UnRegisteredDTO AddUnregisteredUsers(RequestModelUnRegisteredDTO request);
        
    }
}