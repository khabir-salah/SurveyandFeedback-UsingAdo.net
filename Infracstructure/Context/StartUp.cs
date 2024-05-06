using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SurveyAdo.Core.Application.Interfaces.Repository;



namespace SurveyAdo.Infracstructure.Context
{
    public class StartUp : IStartupRepository
    {
        private readonly string _connectionString  = "Server=localhost;User=root;DataBase=surveydb;password=123456789";


        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        public StartUp()
        {
            
        }
        public void CreateDataBase()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = "CREATE DATABASE IF NOT EXISTS SurveyDB";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured when trying to create database" + ex.Message);
            }
        }

        public void createSurveyTable()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"CREATE TABLE Survey(
                           UserEmail varchar(36),
                           Title varchar(200) NOT NULL,
                           Status varchar(36), 
                            Question TEXT NOT NULL,
                            CONSTRAINT fk_UserEmail FOREIGN KEY(UserEmail) REFERENCES registered(Email),
                            UNIQUE (Title),
                            PRIMARY KEY (Title),
                            INDEX (Title)
                           )";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured when trying to create survey table" + ex.Message);
            }
        }

        public void createFeedbackTAble()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"CREATE TABLE Feedback(
                           UserEmail varchar(36),
                           SurveyTitle varchar(200) NOT NULL,
                            Answers Text not null,
                            CONSTRAINT fk_SurveyTitle FOREIGN KEY (SurveyTitle) REFERENCES Survey (Title)
                            
                           )";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured when trying to create feedback table" + ex.Message);
            }
        }

        public void createRegisteredTable()
        {
             try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"CREATE TABLE registered(
                        FirstName varchar(36),
                        LastName varchar(36),
                        Email varchar(36) NOT NULL,
                        Password varchar(36) NOT NULL,
                        Role varchar(20),
                        PRIMARY KEY(Email),
                        UNIQUE (Email)
                           )";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured when trying to create Registered table" + ex.Message);
            }
        }

        public void createUnRegisteredTable()
        {
             try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = @"CREATE TABLE unregistered(
                        Email varchar(36),
                        PRIMARY KEY (Email)
                           )";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured when trying to create UnRegistered table" + ex.Message);
            }
        }
    }
}