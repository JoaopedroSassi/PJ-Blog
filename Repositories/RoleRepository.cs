using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Blog.Repositories
{
    internal class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection sqlConnection)
            => _connection = sqlConnection;

        public List<Role> GetAll()
            => (List<Role>)_connection.GetAll<Role>();

        public Role Get(int id)
            => _connection.Get<Role>(id);

        public void Create(Role role)
        {
            role.Id = 0;
            _connection.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            if (role.Id != 0)
                _connection.Update<Role>(role);
        }

        public void Delete(Role role)
        {
            if (role.Id != 0)
                _connection.Delete<Role>(role);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            Role role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }
    }
}
