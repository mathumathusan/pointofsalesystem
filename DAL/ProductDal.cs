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
  public class ProductDal
    {
        public ProductDal() { 
        
        }

        public static bool Insert(MODEL.Product pro)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"INSERT INTO[dbo].[Products]([product_code],[product_name],[catogary_id]) VALUES ('{pro.product_code}','{pro.product_name}','{pro.catogary_id}')", con);

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
        public static bool Update(MODEL.Product pro)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[Products] SET [product_code] = '{pro.product_code}',[product_name] = '{pro.product_name}',[catogary_id] = '{pro.catogary_id}' WHERE [id]='{pro.Id}'", con);

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
        public static bool Delete(MODEL.Product pro)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM [dbo].[Products] WHERE [id]='{pro.Id}'", con);
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


                SqlCommand cmd = new SqlCommand($"Select * from [dbo].[Products]  where id={id} ", con);
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
        public static DataTable SearchProducts(string columnname, string name)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT [id], [product_code] ,[product_name],[catogary_id] FROM [dbo].[Products] where " + columnname + " like '%" + name + "%'", con);
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
                    cmd.CommandText = "SELECT [id], [product_code] ,[product_name],[catogary_id] FROM [dbo].Products";
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
