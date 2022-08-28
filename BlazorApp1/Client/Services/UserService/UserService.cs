using BlazorApp1.Client.Pages;
using BlazorApp1.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;



namespace BlazorApp1.Client.Services.UserService
{
    public class UserService : IUserService
    {
        public static List<User> users = new List<User>();
        public HttpClient client;
        public UserService(HttpClient http) {
            client = http;
            
        }

        public async  Task<List<User>> getUsers()
        {
            List<User>? result  = await client.GetFromJsonAsync<List<User>>("api/user");
            if (result == null) {
                return new List<User>();
            } 
            return result;
         
        }
        public List<User> getCurrentUsers() {
            return users;
        }

        public async Task<bool> addUser(string id, string name)
        {
            var result = await client.PostAsJsonAsync<User>("api/user" , new User() { Id=id , Name=name});
            if (result.IsSuccessStatusCode == true) {
                return true;
            }
            return false;
            
           
        }


        public User Login(string email, string password)
        {
            return new User() { Id="4" , Name="ali" , Password = "password1"};
        }
    }
}
