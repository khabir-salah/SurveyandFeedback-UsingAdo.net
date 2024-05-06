using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAdo.Core.Application.Interfaces.Repository
{
    public interface IStartupRepository
    {
        void CreateDataBase();
        void createFeedbackTAble();
        void createRegisteredTable();
        void createSurveyTable();
        void createUnRegisteredTable();
        IDbConnection CreateConnection();

    }
}