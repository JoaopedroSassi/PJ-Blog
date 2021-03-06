using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Blog
{
    internal class Program
    {
        private const string CONNECTION_STRING = "Server = localhost,1433;Database=blog;User Id = sa; Password=Loj159951@;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);

            connection.Open();

            /*ReadUsers(connection);
            ReadRoles(connection);
            ReadTags(connection);
            ReadCategories(connection);*/

            //CreateUser(connection);
            //UpdateUser(connection);
            //DeleteUser(connection);


            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            Repository<User> userRepository = new Repository<User>(connection);
            List<User> users = userRepository.GetAll();

            foreach (User user in users)
                Console.WriteLine(user.Name);
        }

        public static void CreateUser(SqlConnection connection)
        {
            Repository<User> userRepository = new Repository<User>(connection);

            User user = new User()
            {
                Id = 4,
                Name = "Mario leston rey",
                Bio = "Sou o mario",
                Email = "mario@leston",
                Image = "https://...",
                PasswordHash = "HASH",
                Slug = "mario-leston"
            };

            userRepository.Create(user);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            Repository<User> userRepository = new Repository<User>(connection);

            User user = new User()
            {
                Id = 4,
                Name = "Mario leston rey rey",
                Bio = "Sou o mario leton rey",
                Email = "mario@leston",
                Image = "https://...",
                PasswordHash = "HASH",
                Slug = "mario-leston"
            };

            userRepository.Update(user);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            Repository<User> userRepository = new Repository<User>(connection);

            User user = userRepository.Get(4);
            userRepository.Delete(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            Repository<Role> roleRepository = new Repository<Role>(connection);
            List<Role> roles = roleRepository.GetAll();

            foreach (Role role in roles)
                Console.WriteLine(role.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            Repository<Tag> roleRepository = new Repository<Tag>(connection);
            List<Tag> tags = roleRepository.GetAll();

            foreach (Tag tag in tags)
                Console.WriteLine(tag.Name);
        }

        public static void ReadCategories(SqlConnection connection)
        {
            Repository<Category> roleRepository = new Repository<Category>(connection);
            List<Category> categories = roleRepository.GetAll();

            foreach (Category category in categories)
                Console.WriteLine(category.Name);
        }
    }
}
