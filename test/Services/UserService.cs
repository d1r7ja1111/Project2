using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.CompilerServices;
using test.Models;
using test.Repositories;
using test.Services.interfaces;

namespace test.Services
{
    public class UserService(IUserRepository _repository) : IUserService
    {
        public Task<IEnumerable<UserModel>> GetAllUsers() => _repository.GetAllUsers();
        public Task<UserModel?> GetUserById(int id) => _repository.GetUserById(id);
        public Task<int> CreateUser(UserModel user) => _repository.Create(user);
        public Task<int> DeleteUser(int id) => _repository.Delete(id);
        public Task<int> UpdateUser(UserModel user) => _repository.Update(user);
    }
}
