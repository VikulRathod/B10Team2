using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Cab.DAL
{
    public class AdminData
    {
        public int InsertCity(string city)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Sp_AddCityInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter CityName = new SqlParameter("@CityName", city);
                cmd.Parameters.Add(CityName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public DataSet CityRecord()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AddCity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            return ds;
        }

        public void DeleteCity(string cityname)
        {
            string query = "DELETE FROM addcity WHERE CityName=@CityName";
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@CityName", cityname);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void UpdateCity(int id,string city)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter CityId = new SqlParameter("@Cityid", id);
                SqlParameter CityName = new SqlParameter("@CityName", city);
                cmd.Parameters.Add(CityId);
                cmd.Parameters.Add(CityName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //public void EditCity(string cityname)
        //{
        //    string query = "Select CityName from AddCity";
        //    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Parameters.AddWithValue("@CityName", cityname);
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //}
    }
}
