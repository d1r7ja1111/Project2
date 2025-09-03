using Microsoft.Data.SqlClient;
using Dapper;
using test.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using test.Repositories;
namespace test.Services
{
    public class UserService
    {
        private readonly Connection con;
        public UserService(Connection con)
        {
            this.con = con;
        }

        public Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return con.GetAllUsers();
        }

        public Task<UserModel?> GetUserById(int id)
        {
            return con.GetUserById(id);
        }
        public Task<int> CreateUser(UserModel user)
        {
            return con.Create(user);
        }
        public Task<int> DeleteUser(int id)
        {
            return con.Delete(id);
        }
        public Task<int> UpdateUser(UserModel user)
        {
            return con.Update(user);
        }
    }
}
