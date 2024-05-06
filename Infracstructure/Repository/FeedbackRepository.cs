using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Domain;
using SurveyAdo.Infracstructure.Context;

namespace SurveyAdo.Infracstructure.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly string _connectionString  = "Server=localhost;User=root;DataBase=surveydb;password=123456789";

        public Feedback AddFeedback(Feedback feedback)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
            //    foreach (var response in feedback.Answers)
            //    {
                 var quary = $"INSERT INTO feedback VALUES('{feedback.UserEmail}', '{feedback.SurveyTitle}', '{JsonSerializer.Serialize(feedback.Answers)}' )";
                using (var command = new MySqlCommand(quary, connection))
                {
                    var addFeedback = command.ExecuteNonQuery();
                    if(addFeedback > 0)
                    {
                        return feedback;
                    }
                    return null;
                }
            //    }
            }
            // return feedback;
        }

        public ICollection<Feedback> GetFeedbacks()
        {
            var feedbacks = new List<Feedback>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"SELECT * FROM feedback ";
                using (var command = new MySqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                           var response =  new Feedback()
                        {
                            UserEmail = reader.GetString("UserEmail"),
                            SurveyTitle = reader.GetString("SurveyTitle"),
                            Answers = JsonSerializer.Deserialize<List<string>>(reader.GetString("Answers"))
                        };
                        feedbacks.Add(response);
                        }
                        
                    }
                }
            }
            return feedbacks;
        }

        public ICollection<Feedback> GetFeedback(string title)
        {
            var feedbacks = new List<Feedback>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT UserEmail, SurveyTitle, Answers FROM Feedback WHERE SurveyTitle = @SurveyTitle";
                using (var command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@SurveyTitle", title);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var response = new Feedback
                            {
                                UserEmail = reader.GetString("UserEmail"),
                                SurveyTitle = reader.GetString("SurveyTitle"),
                                Answers = JsonSerializer.Deserialize<List<string>>(reader.GetString("Answers"))
                            };
                            feedbacks.Add(response);
                        }
                    }
                }
            }
            return feedbacks;
        }
    }
}