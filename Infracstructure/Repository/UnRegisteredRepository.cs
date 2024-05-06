using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Domain;
using SurveyAdo.Infracstructure.Context;

namespace SurveyAdo.Infracstructure.Repository
{
    public class UnRegisteredRepository : IUnRegisteredRepository
    {
        private readonly string _connectionString  = "Server=localhost;User=root;DataBase=surveydb;password=123456789";

        public UnRegistered AddUnregisteredUser(UnRegistered unRegistered)
        {
            using (var connection =  new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"INSERT INTO unregistered VALUES ('{unRegistered.Email}')";
                using (var command = new  MySqlCommand(sql, connection))
                {
                    var addRegister = command.ExecuteNonQuery();
                    if(addRegister > 0)
                    {
                        return unRegistered;
                    }
                }
                return null;
            }
        }

        public ICollection<UnRegistered> GetAllUnRegisteredUsers()
        {
           var UnRegistered = new List<UnRegistered>();
           using (var connection = new MySqlConnection(_connectionString))
           {
            connection.Open();
            var sql = "SELECT * FROM unregistered";
            using (var command = new MySqlCommand(sql, connection))
            {
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var unregistered = new UnRegistered()
                    {
                        Email = reader.GetString("Email")
                    };
                    UnRegistered.Add(unregistered);
                }
            }
           }
           return UnRegistered;
        }

        public UnRegistered GetUnRegisteredUser(string email)
        {
            var unregister = new UnRegistered();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"SELECT Email FROM unregistered WHERE Email = @Email";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            unregister = new UnRegistered()
                            {
                             Email = reader.GetString("Email")
                            };
                        }
                        else{
                            return null;
                        }
                    }

                }
            }
            return unregister;
        }
    }
}