using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Blog.Repositories
{
    internal class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection sqlConnection)
            => _connection = sqlConnection;

        public List<User> GetAll()
            => (List<User>)_connection.GetAll<User>();

        public User Get(int id)
            => _connection.Get<User>(id);

        public void Create(User user)
        {
            user.Id = 0;
            _connection.Insert<User>(user);
        }

        public void Update(User user)
        {
            if(user.Id != 0)
                _connection.Update<User>(user);
        }

        public void Delete(User user)
        {
            if(user.Id != 0)
                _connection.Delete<User>(user);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            User user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }
    }
}
