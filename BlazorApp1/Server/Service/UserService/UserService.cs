using BlazorApp1.Shared;
using BlazorApp1.Server.Exceptions;
namespace BlazorApp1.Server.Service.UserService
{
    public class UserService : IUserService
    {

        public static List<User> users = new List<User>
        {
            new User {Id="1",Email="hamzausmani021@gmail.com" , Password="123455",Name="Hamza Usamni" },
            new User {Id="2",Email="hamzausmani302@gmail.com" , Password="12345",Name="Ali Usamni" },
            new User {Id="3",Email="hamzausmani420@gmail.com" , Password="12345",Name="TEst User" },

        };

        public User addUser(User user)
        {
            
            users.Add(user);
            return user;
        }

        public async  Task<User> getUser(string email , string password= "")
        {
            foreach (User user in users) {
                if (user.Email == email && user.Password == password) {
                    return user;
                }
            }
            throw new NotFound();
        }

        public List<User> getUsers()
        {
            return users;
        }

        public User updateUser(string id, User _user)
        {
            int index = 0;
            foreach (User user in users)
            {
                if (user.Id.Equals(id))
                {
                    users.RemoveAt(index);
                    users.Insert(index, _user);
                    return user;
                }
                index++;
            }
            throw new NotFound();
        }
    }
}
