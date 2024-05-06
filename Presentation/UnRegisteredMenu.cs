using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Application.Service.Implementation;

namespace SurveyAdo.Presentation
{
    public class UnRegisteredMenu
    {
         ISurveyService surveyServices = new SurveyService();

    IRegisteredService userService = new RegisteredService();
    IUnRegisteredService unRegisteredUserServices = new UnRegisteredService();
    IFeedbackService feedbackServices = new FeedbackService();
    Main main= new Main();
        public void GiveFeedback()
        {
             if (surveyServices.ViewAllApprovedSurvey().Count == 0)
        {
            Console.WriteLine("no survey at the moment\ncheck back later");
            main.Menu();
            Console.WriteLine();
        }
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        var unregister = new RequestModelUnRegisteredDTO{Email = email};
        unRegisteredUserServices.AddUnregisteredUsers(unregister);

        var approved = surveyServices.ViewAllApprovedSurvey().ToList();
        int count = 1;
        foreach (var survey in approved)
        {
            Console.WriteLine($"{count}. Survey Title: {survey.Title}");
            count++;
        }
        Console.Write("Enter corresponding number of survey title you want to give feedback on: ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > approved.Count)
        {
            Console.WriteLine("invalid input");
            main.Menu();
        }
        var surveys = approved[choice - 1];
        // bool isEmail = feedbackLogic.CheckIfFeedbackExist(surveys.Title, email);
        // if(isEmail)
        // {
        //     Console.WriteLine("You already gave feedback to this survey");
        //     Menu();
        // }
        // else 
        // {
            var newFeedback = new RequestModelFeedbackDTO{UserEmail = email, SurveyTitle = surveys.Title};
        feedbackServices.GiveFeedback(newFeedback);
        Console.WriteLine("Thank you for your response");
        main.Menu();
        // }


    
        }
    }
}