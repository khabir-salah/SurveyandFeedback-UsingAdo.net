using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SurveyAdo.Core.Application.Interfaces.Repository;
using SurveyAdo.Core.Domain;
using SurveyAdo.Infracstructure.Context;

namespace SurveyAdo.Infracstructure.Repository
{
    public class RegisteredRepository : IRegisteredRepository
    {
        private readonly string _connectionString  = "Server=localhost;User=root;DataBase=surveydb;password=123456789";

        public Registered AddUser(Registered user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = $"INSERT INTO registered VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}', '{user.Role}')";
                using (var command = new MySqlCommand(sql, connection))
                {
                    var addUser = command.ExecuteNonQuery();
                    if(addUser > 0)
                    {
                        return user;
                    }
                    return null;
                }
            }
        }

        public ICollection<Registered> GetAllUsers()
        {
            var users = new List<Registered>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM registered";
                using (var command = new MySqlCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        var registered = new Registered()
                        {
                            FirstName = reader.GetString("firstname"),
                            LastName = reader.GetString("lastname"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("password"),
                            Role = reader.GetString("role"),
                        };
                        users.Add(registered);
                    }
                    // if(!reader.Read())
                    // {
                    //     return null;
                    // }
                }
            }
            return users;
        }

        public Registered GetRegistered(string email)
        {
            var registered = new Registered();
            using(var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM Registered where Email = @email";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        registered = new Registered()
                        {
                            FirstName = reader.GetString("Firstname"),
                            Email = reader.GetString("email"),
                            LastName = reader.GetString("lastname"),
                            Role = reader.GetString("role"),
                            Password = reader.GetString("password"),
                        };
                    }
                    else{
                        return null;
                    }
                }
            }
            return registered;
        }

    }
}