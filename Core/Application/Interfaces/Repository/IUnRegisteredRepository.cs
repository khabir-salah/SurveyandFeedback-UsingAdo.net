using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Repository
{
    public interface IUnRegisteredRepository
    {
        ICollection<UnRegistered> GetAllUnRegisteredUsers();

        UnRegistered AddUnregisteredUser(UnRegistered unRegistered);
        UnRegistered GetUnRegisteredUser(string email);
    }
}