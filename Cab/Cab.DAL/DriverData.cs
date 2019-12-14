using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DAL
{
    public class DriverData
    {
        public int InsertDriverDetails(string Name,string Address,int WorkingCity,string EmailID,string Username,string Password,string DriverPic,int TypeID,string CarName,string CarNumber,string Status)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("AddDriverInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter DName = new SqlParameter("@Name",Name);
                SqlParameter DAddress = new SqlParameter("@Address", Address);
                SqlParameter DWorkingCity = new SqlParameter("@WorkingCity", WorkingCity);
                SqlParameter DEmailID = new SqlParameter("@EmailID", EmailID);
                SqlParameter DUsername = new SqlParameter("@Username", Username);
                SqlParameter DPassword = new SqlParameter("@Password", Password);
                SqlParameter DDriverPic = new SqlParameter("@DriverPic", DriverPic);
                SqlParameter DTypeID = new SqlParameter("@TypeID", TypeID);
                SqlParameter DCarName = new SqlParameter("@CarName", CarName);
                SqlParameter DCarNumber = new SqlParameter("@CarNumber", CarNumber);
                SqlParameter DStatus = new SqlParameter("@Status", Status);
                cmd.Parameters.Add(DName);
                cmd.Parameters.Add(DAddress);
                cmd.Parameters.Add(DWorkingCity);
                cmd.Parameters.Add(DEmailID);
                cmd.Parameters.Add(DUsername);
                cmd.Parameters.Add(DPassword);
                cmd.Parameters.Add(DDriverPic);
                cmd.Parameters.Add(DTypeID);
                cmd.Parameters.Add(DCarName);
                cmd.Parameters.Add(DCarNumber);
                cmd.Parameters.Add(DStatus);
                con.Open();
                return cmd.ExecuteNonQuery();
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
