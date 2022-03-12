using System;
using System.Collections.Generic;
using System.Data;
using mvc.Models.db.sql;
using mvc.Models.viewmodel;
using MySql.Data.MySqlClient;

namespace mvc.Models.db
{
    
    public class UserRepositoryDB : IUserRepository
    {
        private string _connectionString = "Server=localhost;Database=dipl_database;Uid=root;PWD=1234";
        private MySqlConnection _connection;

        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }

            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }

        public void Close()
        {
            if ((this._connection != null) || (this._connection.State != ConnectionState.Open))
            {
                this._connection.Close();
            }
        }

        public User Authenticate(string usernameOrEmail, string password)
        {
            try
            {
                MySqlCommand cmdAuthenticate = this._connection.CreateCommand();
                cmdAuthenticate.CommandText = "SELECT * FROM users WHERE ((username = @usernameOrEmail) AND (passwrd = sha1(@password)) OR ((email = @usernameOrEmail) AND (passwrd = sha1(@password))))";
                cmdAuthenticate.Parameters.AddWithValue("usernameOrEmail", usernameOrEmail);
                cmdAuthenticate.Parameters.AddWithValue("password", password);

                using (MySqlDataReader reader = cmdAuthenticate.ExecuteReader())
                {

                    User user = new User();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user.UserId = reader.GetInt32("userId");
                        user.Firstname = reader.GetString("firstname");
                        user.Lastname = reader.GetString("lastname");
                        user.Age = reader.GetInt32("age");
                        user.Gender = reader["gender"] != DBNull.Value ? (Gender)Convert.ToInt32(reader["gender"]) : Gender.notSpecified;
                        user.Birthdate = Convert.ToDateTime(reader["birthdate"]);
                        user.Email = reader.GetString("email");
                        user.Username = reader.GetString("username");

                        if (Convert.ToInt32(reader["isAdmin"]) == 1)
                        {
                            user.IsAdmin = true;
                        }
                        else
                        {
                            user.IsAdmin = false;
                        }
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            try
            {
                List<User> allUsers = new List<User>();
                MySqlCommand cmdAllUsers = this._connection.CreateCommand();
                cmdAllUsers.CommandText = "SELECT * FROM users";

                using (MySqlDataReader reader = cmdAllUsers.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allUsers.Add(new User
                        {
                            UserId = reader.GetInt32("userId"),
                            Firstname = reader.GetString("firstname"),
                            Lastname = reader.GetString("lastname"),
                            Age = reader.GetInt32("age"),
                            Gender = reader["gender"] != DBNull.Value ? (Gender)Convert.ToInt32(reader["gender"]) : (Gender?)null,
                            Birthdate = reader.GetDateTime("birthdate"),
                            IsAdmin = reader.GetBoolean("isAdmin"),
                            Email = reader.GetString("email"),
                            Password = reader.GetString("passwrd"),
                            Username = reader.GetString("username"),
                        });
                    }
                }
                if (allUsers.Count > 0)
                {
                    return allUsers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteUser(int userToDelete)
        {
            if (userToDelete <= 0)
            {
                return false;
            }
            try
            {
                MySqlCommand cmdDelete = this._connection.CreateCommand();

                cmdDelete.CommandText = "DELETE FROM users WHERE userId = @id";
                cmdDelete.Parameters.AddWithValue("id", userToDelete);

                return cmdDelete.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
