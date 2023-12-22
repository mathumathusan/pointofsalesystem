using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using pos_software.Data;
using pos_software.MODEL;
using System.Data;
using System.Runtime.CompilerServices;



namespace pos_software.DAL
{
   public class CustomerDal:Databaseconfig
    {
        

        public CustomerDal()
        {

        }
        
        public static bool Insert(MODEL.Customer cus)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();
               
                SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[customers] ([id],[customer_name],[address] ,[telephone_no] )   VALUES('{cus.Id}','{cus.customer_name}','{cus.address}','{cus.telephone_no}')", con);

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
        public static bool Update(MODEL.Customer cus)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[customers] SET [customer_name]='{cus.customer_name}',[address]='{cus.address}' ,[telephone_no]='{cus.telephone_no}'   WHERE [id]='{cus.Id}' ", con);

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
        public static bool Delete(MODEL.Customer cus)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM [dbo].[customers] WHERE [id]='{cus.Id}'", con);
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
              

                SqlCommand cmd = new SqlCommand($"Select * from customers where id={id} ", con);
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
        public static DataTable SearchCustomers(string columnname,string name)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand($"Select [id],[customer_name],[address],[telephone_no] from customers where " + columnname + " like '%" + name + "%'", con);
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
                    cmd.CommandText = "Select [id],[customer_name],[address],[telephone_no] from customers";
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
