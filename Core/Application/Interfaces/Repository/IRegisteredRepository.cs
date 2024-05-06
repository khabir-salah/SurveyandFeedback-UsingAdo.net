using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Repository
{
    public interface IRegisteredRepository
    {
          ICollection<Registered> GetAllUsers();
        Registered AddUser(Registered user);
        public Registered GetRegistered(string email);
    }
}