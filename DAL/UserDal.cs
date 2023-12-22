using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace pos_software.DAL
{
    public class UserDal
    {
        public UserDal() { 
        
        }

        public static bool Insert(MODEL.User user)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[users] ([username],[password],[user_type]) VALUES ('{user.username}','{user.password}','{user.user_type}')", con);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;

            }
            finally
            {
                con.Close();
            }
        }
        public static bool Update(MODEL.User user)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[users] SET [username] = '{user.username}',[password] = '{user.password}',[user_type] = '{user.user_type}' WHERE [id]='{user.Id}'", con);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;

            }
            finally
            {
                con.Close();
            }
        }
        public static bool Delete(MODEL.User user)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM [dbo].[users] WHERE [id]='{user.Id}'", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
                // throw;

            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable getAllById(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {


                SqlCommand cmd = new SqlCommand($"Select * from [dbo].[users]  where id={id} ", con);
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cmd.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
                // throw;

            }
            finally
            {
                con.Close();
            }
        }
        public static DataTable SearchUsers(string columnname, string name)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT [id], [username] ,[password],[user_type] FROM [dbo].[users] where " + columnname + " like '%" + name + "%'", con);
                con.Open();

                dt.Load(cmd.ExecuteReader());
                cmd.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // return null;
                throw;

            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable GetAll()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                using (con)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT [id], [username] ,[password],[user_type] FROM [dbo].users";
                    cmd.CommandType = CommandType.Text;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    cmd.Dispose();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;

            }
            return dt;
        }
    }
}

