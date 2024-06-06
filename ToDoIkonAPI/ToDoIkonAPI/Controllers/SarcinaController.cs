using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ToDoIkonAPI.Models;

namespace ToDoIkonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SarcinaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SarcinaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("AddSarcina")]

        public Response AddSarcina(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.AddSarcina(sarcina, connection);

            return response;
        }
        [HttpPost]
        [Route("TaskCompleted")]
        public Response TaskDone(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.TaskDone(sarcina, connection);

            return response;
        }
        [HttpPost]
        [Route("UpdateSarcina")]
        public Response UpdateSarcina(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.UpdateSarcina(sarcina, connection);

            return response;
        }
        [HttpPost]
        [Route("UpdateSarcinaFull")]
        public Response UpdateSarcinaFull(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.UpdateSarcinaFull(sarcina, connection);

            return response;
        }
        [HttpPost]
        [Route("SarcinaListOldestToNewest")]

        public Response SarcinaListOldestToNewest(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.SarcinaListOldestToNewest(sarcina,connection);

            return response;
        }
        [HttpPost]
        [Route("SarcinaListNewestToOldest")]

        public Response SarcinaListNewestToOldest(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.SarcinaListNewestToOldest(sarcina, connection);

            return response;
        }
        [HttpPost]
        [Route("SarcinaListCompletedLast")]

        public Response SarcinaListCompletedLast(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.SarcinaListCompletedLast(sarcina, connection);

            return response;
        }
        [HttpDelete]
        [Route("DeleteCompletedTask")]

        public Response DeleteCompletedSarcina(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.DeleteCompletedSarcina(sarcina, connection);

            return response;
        }
        [HttpDelete]
        [Route("DeleteTask")]
        public Response DeleteSarcina(Sarcina sarcina)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ToDoIkonConnectionString").ToString());
            Dal dal = new Dal();
            response = dal.DeleteSarcina(sarcina, connection);

            return response;
        }
    }
}
