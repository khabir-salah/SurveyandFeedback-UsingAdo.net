using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Application.Service.Implementation;

namespace SurveyAdo.Presentation
{
    public class ClientMenu
    {
         ISurveyService  surveyServices = new SurveyService();
        IFeedbackService feedbackLogic = new FeedbackService();
        IRegisteredService registeredService= new RegisteredService();

        Main mainMenu = new Main();
        public void Clientmen()
        {
            Console.WriteLine();
            Console.WriteLine("========= CLIENT PAGE ==========");
            Console.WriteLine("Enter\n1. To create survey \n2. To view survey by status\n3. To view survey feedback\n4. To exist");
            int choice = 5;
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                choice = num;
            }
            switch (choice)
            {
                case 1:
                    CreatSurvey();
                    Clientmen();
                break;
                case 2:
                    ViewSurveyByStatus();
                    Clientmen();
                break;
                case 3:
                    ViewFeedback();
                    Clientmen();
                break;
                case 4:
                    mainMenu.Menu();
                break;
                default:
                    Console.WriteLine("enter a valid number");
                break;
                
            }
        }

        public void CreatSurvey()
        {
            List<string> questions = new List<string>();
            Console.Write("enter title of your survey: ");
            string title = Console.ReadLine();

            Console.Write("How many question are under this survey: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Enter {i+1} question: ");
                string question = Console.ReadLine();
            //      Console.WriteLine("Enter 1 for closed type question\n2 for open type question ");
            // string choice = Console.ReadLine();
            // if(choice == "1")
            // {
            //     Console.WriteLine("how many option do u want under this question")  ;              
            //         int choice2 = int.Parse(Console.ReadLine());
            //         for (int j = 0; j < choice2; j++)
            //         {
            //             Console.WriteLine($"Enter {j+1} option");
            //             string option = Console.ReadLine();
            //             questions.Add(option);
            //         }
            // }
            // else if(choice == "2")
            // {

            // }
                questions.Add(question);
            }
            var surveyquestion = new RequestModelSurveyDTO(){Question = questions, Title = title };
            surveyServices.CreatSurvey(surveyquestion);
            if(surveyquestion == null)
            {
                Console.WriteLine("Survey title already exist");
            }
            else
            {
                Console.WriteLine("survey succesfully created ");
            }
        }

         public void ViewSurveyByStatus()
        {
            Console.WriteLine("Enter\n1. To view approved survey\n2. To view denied survey\n3. To view pending survey");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                ViewApprovedSurvey();
            }
            else if(choice == 2)
            {
                ViewDeniedSurvey();
            }
            else if(choice == 3)
            {
                ViewPendingSurvey();
            }
            else
            {
                Console.WriteLine("Enter a valid number");
            }
        }

        public void ViewApprovedSurvey()
        {
            if(surveyServices.GetApprovedSurveyByClient(registeredService.GetCurrentUser().Email).Count == 0)
            {
                Console.WriteLine("No approved survey at the moment");
                Clientmen();
                Console.WriteLine();
            }
            var approved = surveyServices.GetApprovedSurveyByClient(registeredService.GetCurrentUser().Email);
             int count = 1;
            foreach (var survey in approved)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }
        }

        public void ViewPendingSurvey()
        {
            if(surveyServices.GetPendingSurveyByClient(registeredService.GetCurrentUser().Email).Count == 0)
            {
                Console.WriteLine("No pending survey at the moment");
                Clientmen();
                Console.WriteLine();
            }
            var approved = surveyServices.GetPendingSurveyByClient(registeredService.GetCurrentUser().Email);
             int count = 1;
            foreach (var survey in approved)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }
        }

        public void ViewDeniedSurvey()
        {
            if(surveyServices.GetDeniedSurveyByClient(registeredService.GetCurrentUser().Email).Count == 0)
            {
                Console.WriteLine("No denied survey at the moment");
                Clientmen();
                Console.WriteLine();
            }
            var denied = surveyServices.GetDeniedSurveyByClient(registeredService.GetCurrentUser().Email);
             int count = 1;
            foreach (var survey in denied)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }
        }

          public void ViewFeedback()
        {
            if(surveyServices.GetApprovedSurveyByClient(registeredService.GetCurrentUser().Email).Count == 0)
            {
                Console.WriteLine("no feedback at the moment check back later");
                Clientmen();
                Console.WriteLine();
            }
            var approved = surveyServices.GetApprovedSurveyByClient(registeredService.GetCurrentUser().Email).ToList();
             int count = 1;
            foreach (var survey in approved)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");   
                count++;
            }
            Console.WriteLine("Enter corresponding number of survey title you want to view feedback on");
            int choice;
            if(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > approved.Count)
            {
                Console.WriteLine("invalid input");
                Clientmen();
            }
            var surveys = approved[choice-1];
            var feedbacks = feedbackLogic.GetFeedbacks(approved[--choice].Title);
            foreach (var item in feedbacks)
            {
                Console.WriteLine($"{item.UserEmail} ");
                for (int i = 0; i < item.Answers.Count; i++)
                {
                    Console.WriteLine($"Question: {surveys.Question[i]}");
                    Console.WriteLine($"Response: {item.Answers[i]}");
                }
            }
        }

        public void QuestionType()
        {
            Console.WriteLine("Enter 1 for closed type question\n2 for open type question ");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":

                    Console.WriteLine("how many option do u want under this question")  ;              
                    int choice2 = int.Parse(Console.ReadLine());
                    for (int i = 0; i < choice2; i++)
                    {
                        Console.WriteLine($"Enter {i+1} option");
                        string option = Console.ReadLine();
                    }
                break;
                case "2":

                break;
            }
        }
    }
}