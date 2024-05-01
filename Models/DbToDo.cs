using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class DbToDo

    { 

        private SqlConnection con;
        private void connection()
        {

            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
          
        }

        public List<ToDoMdl> GetToDo(int Userid)
        {
          
            connection();
            List<ToDoMdl> ToDoList = new List<ToDoMdl>();
           
            SqlCommand cmd = new SqlCommand("GetToDoById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", Userid);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

          
            foreach (DataRow dr in dt.Rows) {
                ToDoList.Add
                (
                    new ToDoMdl
                    {
                        Id = Convert.ToInt32(dr["ToDoid"]),
                        Title=Convert.ToString(dr["title"]),
                        Description=Convert.ToString(dr["description"]),
                        strCreatedDate=dr["created_date"].ToString(),
                        strUpdatedDate=dr["updated_date"].ToString(),
                        Checkbox=Convert.ToBoolean( dr["checkbox"]),
                       
                    });
        }
           
                return ToDoList;
            

              
        }

     

        public bool AddToDo(ToDoMdl td)
        {
            try
            {
            connection();
            SqlCommand cmd = new SqlCommand("AddToDo",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("title", td.Title);
            cmd.Parameters.AddWithValue("description", td.Description);
            cmd.Parameters.AddWithValue("userid", td.Id);
           
            con.Open();
            int i= cmd.ExecuteNonQuery();
            con.Close();


         
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception)
            {
                throw;
                
            }
        }

        public bool checkedtodo(ToDoMdl td)
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("Proc_post_todotbl_check_status", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", td.Id);
                cmd.Parameters.AddWithValue("checked", td.Checkbox);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                con.Open();
                // int i = cmd.ExecuteNonQuery();
                con.Close();

                


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
            
        }
        public bool GetToDoById(int id)
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("GetToDoById", con);
               

                cmd.Parameters.AddWithValue("id", id);
 
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }

        }

        public bool UpdateToDo(ToDoMdl td)
        {
            
            connection();
            SqlCommand cmd = new SqlCommand("UpdateToDo",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", td.Id);
            cmd.Parameters.AddWithValue("title", td.Title);
            cmd.Parameters.AddWithValue("description", td.Description);
           //cmd.Parameters.AddWithValue("updated_date", td.UpdatedDate);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();

            
            try
            {
                if (i >= 1)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

     


        public bool DeleteToDo(int Id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteToDo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id",Id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            try
            {
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Register(User reg)
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("proc_register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("Id", reg.Id);
                cmd.Parameters.AddWithValue("firstname", reg.FirstName);
                cmd.Parameters.AddWithValue("lastname", reg.LastName);
                cmd.Parameters.AddWithValue("email", reg.Email);
                cmd.Parameters.AddWithValue("address", reg.Address);
                cmd.Parameters.AddWithValue("gender", reg.Gender);
                cmd.Parameters.AddWithValue("contact", reg.Contact);
                cmd.Parameters.AddWithValue("dob", reg.DOB);
                cmd.Parameters.AddWithValue("password", reg.Password);
                cmd.Parameters.AddWithValue("confirm", reg.Confirm);
       
               

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();



                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;

            }
        }

        public bool Login(User2 us)
        {
            connection();
            SqlCommand cmd = new SqlCommand("proc_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("email", us.Email);
            cmd.Parameters.AddWithValue("password", us.Password);
           // cmd.Parameters.AddWithValue("id", us.id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            try
            {
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}