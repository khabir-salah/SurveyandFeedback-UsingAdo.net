using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Esf;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Domain;
using SurveyAdo.Infracstructure.Repository;

namespace SurveyAdo.Core.Application.Service.Implementation
{
    public class UnRegisteredService : IUnRegisteredService
    {
        IUnRegisteredRepository unRegisteredRepo = new UnRegisteredRepository();
        public UnRegisteredDTO AddUnregisteredUsers(RequestModelUnRegisteredDTO request)
        {
            var isExist = IsEmailExist(request.Email);
            if(isExist == false)
            {
                  var unRegister = new UnRegistered() 
                {
                    Email = request.Email,
                };
                unRegisteredRepo.AddUnregisteredUser(unRegister);
                var unRegisterDto = new UnRegisteredDTO()
                {
                    Email = unRegister.Email,
                };
                return unRegisterDto;
            }
                return null;
          
        }

        private bool IsEmailExist(string email)
        {
            var isExist = unRegisteredRepo.GetUnRegisteredUser(email);
            if(isExist == null)
            {
                return false;
            }
            return true;
        }
    }
}