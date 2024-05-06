using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Domain;
using SurveyAdo.Infracstructure.Repository;

namespace SurveyAdo.Core.Application.Service.Implementation
{
    public class RegisteredService : IRegisteredService
    {
    public static Registered LoggedInUser { get; set; } = default!;

        IRegisteredRepository registeredRepo = new RegisteredRepository();
        public RegisteredDTO GetUser(string email)
        {
            var ifExists = registeredRepo.GetRegistered(email);
            if (ifExists == null)
            {
                return null;
            }
            return new RegisteredDTO
            {
                Email = email,
                FirstName = ifExists.FirstName,
                LastName = ifExists.LastName,
                Role = ifExists.Role,                
            };
        }

        public RegisteredDTO RegisterUser(RequestModelRegisteredDTO request)
        {
            var checkIfExist = registeredRepo.GetRegistered(request.Email);
            if (checkIfExist != null)
            {
                return null;
            }
            var registered = new Registered
            {
                Email = request.Email,
                FirstName = request.FirstName,
                Password = request.Password,
                Role = "Client",
                LastName = request.LastName,
            };
            registeredRepo.AddUser(registered);
            return new RegisteredDTO
            {
                Email = registered.Email,
                FirstName = registered.FirstName,
                LastName = registered.LastName,
                Role = registered.Role,
            };
        }

        public RegisteredDTO UserLogin(RequestLogInDTO request)
        {
           var checkUser = registeredRepo.GetRegistered(request.Email);
           if (checkUser == null )
           {
            return null;
           }
           if(checkUser.Password.ToLower() != request.Password.ToLower() )
           {
            return null;
           }
           if(checkUser.Email.ToLower() != request.Email.ToLower())
           {
            return null;
           }
           LoggedInUser = checkUser;
           return  new RegisteredDTO
           {
                FirstName = checkUser.FirstName,
                Email = checkUser.Email,
                LastName = checkUser.LastName,
                Role = checkUser.Role,
           };
           
        }

        public Registered GetCurrentUser()
        {
            return LoggedInUser;
        }
    }
}