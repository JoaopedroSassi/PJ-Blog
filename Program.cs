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

            ReadUsers(connection);
            ReadRoles(connection);


            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            UserRepository userRepository = new UserRepository(connection);
            List<User> users = userRepository.GetAll();

            foreach (User user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            RoleRepository roleRepository = new RoleRepository(connection);
            List<Role> roles = roleRepository.GetAll();

            foreach (Role role in roles)
                Console.WriteLine(role.Name);
        }
    }
}
