using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ecomDAL
    {
        public static bool Validate(string username, string password)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            string connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\USER105\SOURCE\REPOS\MVC\ECOOMERCEMVC\APP_DATA\DATABASE1.MDF;Integrated Security=True";
            conn.ConnectionString = connstr;
            string qry = "select * from sid where Username=@uname and Password=@pwd";

            cmd.CommandText = qry;
            cmd.Parameters.Add(new SqlParameter("@uname", username));
            cmd.Parameters.Add(new SqlParameter("@pwd", password));
            cmd.Connection = conn;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    status = true;
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
    }
}
