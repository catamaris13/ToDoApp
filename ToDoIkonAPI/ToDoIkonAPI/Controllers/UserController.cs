using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ToDoIkonAPI.Models;

namespace ToDoIkonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Registration")]

        public Response Registration(User user)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.Registration(user, connection);

            return response;
        }
        [HttpPost]
        [Route("Login")]
        public Response Login(User user)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.Login(user, connection);

            return response;
        }
    }
}
