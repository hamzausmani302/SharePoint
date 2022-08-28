using BlazorApp1.Shared;
namespace BlazorApp1.Server.Service.UserService
{
    public interface IUserService
    {
        public Task<User> getUser(string email , string password ="");
        public List<User> getUsers();
        public User addUser(User user);

        public User updateUser(string id, User user);


    }
}
