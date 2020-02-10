using System;
using Dapper;
using webapi.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace webapi.Services
{
    public class UserService : IUserService
    {
        MySqlConnection connection = new MySqlConnection();
        string connectionString = @"server=localhost;uid=root;password=123;database=db1";
        public List<User> GetUsers()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();

            //MySqlCommand cmd = new MySqlCommand("SELECT * FROM fruits", connection);
            var details = connection.Query<User>("select * from user");
            //MySqlDataReader rd = cmd.ExecuteReader();
            connection.Close();

            return details.ToList();
            // rd.Close();

        }

        public void AddUsers(User u)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO user (userid, name, number) VALUES (@userid, @name, @number);", connection);
                cmd.Parameters.AddWithValue("@userid", u.userid);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@number", u.number);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void UpdateUsers(User u)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd2 = new MySqlCommand("UPDATE user SET userid=@userid, name=@name, number=@number WHERE userid=@userid", connection);
                cmd2.Parameters.AddWithValue("@userid", u.userid);
                cmd2.Parameters.AddWithValue("@name", u.name);
                cmd2.Parameters.AddWithValue("@number", u.number);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void DeleteUsers(User u)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM user WHERE userid=@userid", connection);
                cmd3.Parameters.AddWithValue("@userid", u.userid);
                cmd3.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

}