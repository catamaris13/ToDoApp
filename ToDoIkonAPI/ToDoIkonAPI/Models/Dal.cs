using Azure;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ToDoIkonAPI.Models
{
    public class Dal
    {
        public Response Registration(User user, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into [User] (Username,Email,Password) Values('" + user.Username + "','" + user.Email + "','" + user.Password + "')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Registration successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration failed";
            }
            return response;
        }
        public Response Login(User user, SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter da = new SqlDataAdapter("select * from [User] where Username= '" + user.Username + "'and Password='" + user.Password + "'", connection); ;


            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login Successful";
                User us = new User();
                us.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                us.Username = Convert.ToString(dt.Rows[0]["Username"]);
                us.Email = Convert.ToString(dt.Rows[0]["Email"]);
                
                response.User = us;
            }

            else
            {   
                response.StatusCode = 100;
                response.StatusMessage = "Wrong Username or Password";
                response.User = null;
            }

            return response;
        }

        public Response AddSarcina(Sarcina sarcina, SqlConnection connection)
        {
            Response response = new Response();
            try
            {

                SqlCommand cmd = new SqlCommand("Insert into Sarcina(Username,Cerinta,Activ) Values('" + sarcina.Username + "','" + sarcina.Cerinta + "',1)", connection);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Sarcina adaugata cu succes";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Nu s-a putut adauga sarcina";
                }
            }
            catch (SqlException ex)
            {
                // Check if the exception is due to a foreign key constraint violation
                if (ex.Number == 547)
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Foreign key constraint violated: " + ex.Message;
                }
                else
                {
                    // Handle other SQL exceptions
                    response.StatusCode = 100;
                    response.StatusMessage = "An error occurred: " + ex.Message;
                }
            }

            return response;
        }
        public Response SarcinaListOldestToNewest(Sarcina sarcina, SqlConnection connetion)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sarcina where Username='" + sarcina.Username + "' order by Id", connetion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Sarcina> list = new List<Sarcina>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sarcina sar = new Sarcina();
                    sar.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    sar.Username = Convert.ToString(dt.Rows[i]["Username"]);
                    sar.Cerinta = Convert.ToString(dt.Rows[i]["Cerinta"]);
                    sar.Activ = Convert.ToInt32(dt.Rows[i]["Activ"]);

                    list.Add(sar);
                }
                if (list.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Sarcini Gasite";
                    response.listSarcina = list;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Nu au fost gasite sarcini";
                    response.listSarcina = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Nu au fost gasite sarcini";
                response.listSarcina = null;
            }
            return response;
        }
        public Response SarcinaListNewestToOldest(Sarcina sarcina, SqlConnection connetion)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sarcina where Username='" + sarcina.Username + "' order by Id desc", connetion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Sarcina> list = new List<Sarcina>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sarcina sar = new Sarcina();
                    sar.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    sar.Username = Convert.ToString(dt.Rows[i]["Username"]);
                    sar.Cerinta = Convert.ToString(dt.Rows[i]["Cerinta"]);
                    sar.Activ = Convert.ToInt32(dt.Rows[i]["Activ"]);

                    list.Add(sar);
                }
                if (list.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Sarcini Gasite";
                    response.listSarcina = list;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Nu au fost gasite sarcini";
                    response.listSarcina = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Nu au fost gasite sarcini";
                response.listSarcina = null;
            }
            return response;
        }
        public Response SarcinaListCompletedLast(Sarcina sarcina, SqlConnection connetion)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sarcina where Username='" + sarcina.Username + "' order by Activ desc", connetion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Sarcina> list = new List<Sarcina>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Sarcina sar = new Sarcina();
                    sar.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    sar.Username = Convert.ToString(dt.Rows[i]["Username"]);
                    sar.Cerinta = Convert.ToString(dt.Rows[i]["Cerinta"]);
                    sar.Activ = Convert.ToInt32(dt.Rows[i]["Activ"]);

                    list.Add(sar);
                }
                if (list.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Sarcini Gasite";
                    response.listSarcina = list;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Nu au fost gasite sarcini";
                    response.listSarcina = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Nu au fost gasite sarcini";
                response.listSarcina = null;
            }
            return response;
        }
        public Response TaskDone(Sarcina sarcina, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Sarcina set Activ = 0 where Id='"+ sarcina.Id+ "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Completed";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Fail to Complete";
            }
            return response;
        }
        public Response UpdateSarcina(Sarcina sarcina, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Sarcina set Cerinta ='"+sarcina.Cerinta+"' where Id='"+sarcina.Id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Fail to Update";
            }
            return response;
        }
        public Response UpdateSarcinaFull(Sarcina sarcina, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update Sarcina set Cerinta ='" + sarcina.Cerinta + "', Activ='"+sarcina.Activ+"' where Id='" + sarcina.Id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Fail to Update";
            }
            return response;
        }
        public Response DeleteCompletedSarcina(Sarcina sarcina, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from Sarcina where Username='" + sarcina.Username + "' and Activ=0", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Task deletion failed";
            }
            return response;
        }
        public Response DeleteSarcina(Sarcina sarcina, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from Sarcina where Id='" + sarcina.Id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Task Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Task deletion failed";
            }
            return response;
        }

    }
}
