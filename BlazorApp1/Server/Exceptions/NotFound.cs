namespace BlazorApp1.Server.Exceptions
{
    public class NotFound : Exception
    {
        public int statusCode = 404;
        public NotFound(string message = "Not found"): base(message) { 
            
        }
    }
}
