using BlazorApp1.Shared;

namespace BlazorApp1.Client.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> getUsers();
        public List<User> getCurrentUsers();
        public Task<bool> addUser(string id , string name);
        public User Login(string email, string password);
    }
}
