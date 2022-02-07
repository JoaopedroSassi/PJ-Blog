using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    internal class Program
    {
        private const string CONNECTION_STRING = "Server = localhost,1433;Database=blog;User Id = sa; Password=Loj159951@;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            //ReadUsers();
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
        }

        public static void ReadUsers()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach(User user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                User user = connection.Get<User>(1);
                Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser()
        {
            User user = new User()
            {
                Name = "Mario leston rey",
                Bio = "Sou o mario",
                Email = "mario@leston",
                Image = "https://...",
                PasswordHash = "HASH",
                Slug = "mario-leston"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
        }

        public static void UpdateUser()
        {
            User user = new User()
            {
                Id = 3,
                Name = "Mario leston rey rey",
                Bio = "Sou o mario leton rey",
                Email = "mario@leston",
                Image = "https://...",
                PasswordHash = "HASH",
                Slug = "mario-leston"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                Console.WriteLine("Att realizado com sucesso!");
            }
        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                User user = connection.Get<User>(3);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizada com sucesso!");
            }
        }

    }
}
