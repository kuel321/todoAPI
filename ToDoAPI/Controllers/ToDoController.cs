using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    public class ToDoController : ApiController
    {   
        public HttpResponseMessage Get() //GET METHOD
        {
            string query = @"
            select todoID,todoName from 
             dbo.todo";
            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ToDoAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
                using (var da= new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

            
        }

        public string Post(ToDo todo) //POST METHOD
        {
            try
            {
                string query = @"
                 insert into dbo.todo values
                 ('" + todo.todoName + @"')
                 ";

                
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ToDoAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Succesfully";

            }
            catch (Exception)
            {
                return "Failed to Post";

            }


        }
        public string Put(ToDo todo) //PUT METHOD
        {
            try
            {
                string query = @"
                  update dbo.todo set todoName=
                 '" + todo.todoName + @"'
                 where todoID=" + todo.todoID + @"
                 ";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ToDoAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Update Succesful";

            }
            catch (Exception)
            {
                return "Failed to Update";

            }

        }
        public string Delete(int id) //DELETE METHOD
        {
            try
            {
                string query = @"
                  delete from dbo.todo 
                 where todoID=" + id + @"
                 ";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ToDoAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Succesfully";

            }
            catch (Exception)
            {
                return "Failed to delete";

            }

        }

    }
    
}
