using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SurveyAdo.Core.Application.DTOs;
using SurveyAdo.Core.Application.Interfaces.Service;
using SurveyAdo.Core.Application.Service.Implementation;
using SurveyAdo.Core.Domain;

namespace SurveyAdo.Presentation
{
    public class Main
    {

    IRegisteredService userService = new RegisteredService();

    public void Menu()
    {
        Console.WriteLine("===  Welcome to Survey and Feedback App  ===");
        Console.WriteLine("Enter \n1. To register \n2. To login\n3. To give feedback to a survey");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Enter a valid number");
            Menu();
        }
        switch (choice)
        {
            case 1:
                Register();
                break;
            case 2:
                Login();
                break;
            case 3:
                UnRegisteredMenu unRegistered = new UnRegisteredMenu();
                unRegistered.GiveFeedback();
                break;
        }
    }

     private void Register()
    {
        Console.WriteLine();
        Console.WriteLine("====== REGISTRATION PAGE ========");
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        var newClient = new RequestModelRegisteredDTO(){Email = email, Password = password, FirstName = firstName, LastName = lastName};
        var user = userService.RegisterUser(newClient);
        Console.WriteLine();
        if (user == null)
        {
            Console.WriteLine("Email already exist");
            Console.WriteLine();
            Menu();
        }
        else
        {
            Console.WriteLine("Registration successfull");
            Console.WriteLine();
            Menu();
        }

    }



    public void Login()
    {
        Console.WriteLine();
         Console.WriteLine("========= LOGIN PAGE =========");
        Console.Write("Enter your email name: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        var logIn = new RequestLogInDTO(){Email = email, Password = password,};
        var user = userService.UserLogin(logIn);
        if (user == null)
        {
            Console.WriteLine("User doesnt exist");
            Console.WriteLine();
            Menu();
        }
        else
        {
            Console.WriteLine("Login successfull");
            Console.WriteLine();
            if (user.Role == "Admin")
            {
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.AdminMen();
            }

            else if (user.Role == "Client")
            {
                ClientMenu clientMenu = new ClientMenu();
                clientMenu.Clientmen();
            }
        }

    }
    
    }
}