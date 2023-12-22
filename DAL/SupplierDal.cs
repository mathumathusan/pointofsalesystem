using pos_software.Data;
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
    public class SupplierDal:Databaseconfig
    {
        public SupplierDal()
        {


        }

        public static bool Insert(MODEL.Supplier sup)
        {
             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[suppliers] ([supplier_name],[address],[telephone_no]) VALUES ('{sup.supplier_name}','{sup.address}','{sup.telephone_no}')", con);

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
        public static bool Update(MODEL.Supplier sup)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE [dbo].[suppliers] SET [supplier_name] = '{sup.supplier_name}',[address] = '{sup.address}',[telephone_no] = '{sup.telephone_no}' WHERE [id]='{sup.Id}'", con);

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
        public static bool Delete(MODEL.Supplier sup)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM [dbo].[suppliers] WHERE [id]='{sup.Id}'", con);
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


                SqlCommand cmd = new SqlCommand($"Select * from [dbo].[suppliers]  where id={id} ", con);
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
        public static DataTable SearchSuppliers(string columnname, string name)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT [id], [supplier_name] ,[address],[telephone_no] FROM [dbo].[suppliers] where " + columnname + " like '%" + name + "%'", con);
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
                    cmd.CommandText = "SELECT [id], [supplier_name] ,[address],[telephone_no] FROM [dbo].[suppliers]";
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
