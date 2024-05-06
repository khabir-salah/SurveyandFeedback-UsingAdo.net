using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Service
{
    public interface IRegisteredService
    {
         RegisteredDTO RegisterUser(RequestModelRegisteredDTO request);


        RegisteredDTO UserLogin(RequestLogInDTO request);


        RegisteredDTO GetUser(string email);
        public Registered GetCurrentUser();
    }
}