using BlazorApp1.Server.Service.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using BlazorApp1.Server.Service;
using BlazorApp1.Shared;
using System.Globalization;
//using BlazorApp1.Server.Exceptions;
using BlazorApp1.Server.DTO;
using BlazorApp1.Server.Service.FileDBService;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {

        private FileDBService fileService;
        public IUserService userService;
       

        public UserController(IUserService _userService, FileDBService service) {
            userService = _userService;
            fileService = service;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> login(LoginDTO user) {
            Console.WriteLine("emial");
            try
            {
                User _user = await userService.getUser(user.Email, user.Password);
                if (_user == null)
                {
                    return NotFound();
                }
                return Ok(_user);

            }
            catch (Exception) {
                return NotFound();        
            }
        }   

        [HttpGet]
        public async Task<List<User>> getUsers() {
            List<User> users = userService.getUsers();


            return users;
        }

        [HttpGet("{id}")]

        public ActionResult<User> getUser(string id)
        {
            return new User();

            
        }

        [HttpPost]
        public User addUser(User _user) {
            User user = new() { Id = _user.Id, Name = _user.Name };
            userService.addUser(user);
            return user;
        }
        [HttpPut("{id}")]
        public ActionResult <User> updateUser(string id , UserUpdate _user) {
            try
            {
              
                User user = userService.updateUser(id, new User() { Id = id, Name = _user.Name });
                return Ok(user);
            }
            catch (BlazorApp1.Server.Exceptions.NotFound)
            {
                return NotFound();
            }
         
            
        }


    }
}
