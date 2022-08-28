using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace BlazorApp1.Server.Controllers
{
    
    [Route("api")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string testRoute()
        {
            return "connected";
        }
        [HttpGet("test1")]
        public JsonResult test()
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("name", "hamza");
            response.Add("class", "2b");

            return new JsonResult(response);
        }
    }
}