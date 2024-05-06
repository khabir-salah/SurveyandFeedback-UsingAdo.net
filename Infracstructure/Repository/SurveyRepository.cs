using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Domain;
using SurveyAdo.Core.Domain.Enum;
using SurveyAdo.Infracstructure.Context;

namespace SurveyAdo.Infracstructure.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly string _connectionString  = "Server=localhost;User=root;DataBase=surveydb;password=123456789";

        public Survey AddSurvey(Survey survey)
        {
            var result = new List<int>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                // foreach (var question in survey.Question)
                // {
                    var sql = $" INSERT INTO survey VALUES('{survey.UserEmail}', '{survey.Title}', '{(int)survey.Status}', '{JsonSerializer.Serialize(survey.Question)}')";
                using(var command = new MySqlCommand(sql, connection))
                {
                    var addSurvey = command.ExecuteNonQuery();
                    result.Add(addSurvey);
                }
                // }
            }
            if(result.Any(x => x == 0))
            {
                return null;
            }
            return survey;
        }

        

        public ICollection<Survey> GetSurveyByUser(string email)
        {
            var surveyByUser =  new List<Survey>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Survey WHERE UserEmail = @email ";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        var userSurvey = new Survey
                        {
                            UserEmail = reader.GetString("UserEmail"),
                            Status = (Status)reader.GetInt32("Status"),
                            Title = reader.GetString("title"),
                            Question = JsonSerializer.Deserialize<List<string>>(reader.GetString("Question"))
                        };
                        
                        surveyByUser.Add(userSurvey);
                    }
                }
                return surveyByUser;
            }
        }


        public bool IsDelete(string title)
        {
            throw new NotImplementedException();
        }

        public ICollection<Survey> GetAllSurvey()
        {
            var listSurvey = new List<Survey>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"SELECT * FROM survey";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                         while (reader.Read())
                    {
                        var survey = new Survey()
                        {
                            UserEmail = reader.GetString("UserEmail"),
                            Status = (Status)reader.GetInt32("Status"),
                            Title = reader.GetString("Title"),
                            Question = JsonSerializer.Deserialize<List<string>>(reader.GetString("Question"))
                        };
                       listSurvey.Add(survey);
                    }
                    }
                   
                }
            }
            return listSurvey;
        }

        public Survey GetSurvey(string title)
        {
            Survey survey = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT useremail, title, status, question FROM survey WHERE title = @title";
                using (var command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@title", title);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             survey = new Survey
                            {
                                UserEmail = reader.GetString("useremail"),
                                 Title = reader.GetString("Title"),
                                 Status = (Status)reader.GetInt32("Status"),
                                 Question = JsonSerializer.Deserialize<List<string>>(reader.GetString("Question"))
                            };
                        }
                    }
                }
            }
            return survey;
        }
        public bool UpdateSurvey(string title, Status status)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "UPDATE survey SET Status = @status WHERE Title = @title";
                using (var command = new MySqlCommand(sql, connection))
                {
                    connection.Open();  
                    command.Parameters.AddWithValue(@"title", title);
                    command.Parameters.AddWithValue(@"status", status);
                    var rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

    }
}