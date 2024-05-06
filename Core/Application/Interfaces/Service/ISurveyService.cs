using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Core.Application.Interfaces.Service
{
    public interface ISurveyService
    {
        SurveyDTO CreatSurvey(RequestModelSurveyDTO request);


        SurveyDTO GetSurvey(string title);



        bool IsDelete(string title);


        // public Survey GetSurvey(string title);


        ICollection<SurveyDTO> GetSurveysByUser();


        ICollection<SurveyDTO> GetAllDeniedSurvey();

        ICollection<SurveyDTO> GetDeniedSurveyByClient(string email);


        ICollection<SurveyDTO> GetApprovedSurveyByClient(string email);

        ICollection<SurveyDTO> GetPendingSurveyByClient(string email);


        ICollection<SurveyDTO> ViewAllApprovedSurvey();

        ICollection<SurveyDTO> GetAllPendingSurvey();
    }
}