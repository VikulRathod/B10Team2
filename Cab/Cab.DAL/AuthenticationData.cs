using Cab.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab.DAL
{
    public class AuthenticationData
    {
        public User AuthenticateUser(User user)
        {
            User userInfo = new User() { UserName = user.UserName, Password = user.Password };

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUsername = new SqlParameter("@UserName", user.UserName);
                SqlParameter paramPassword = new SqlParameter("@Password", user.Password);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    userInfo.RetryAttempts = Convert.ToInt32(rdr["RetryAttempts"].ToString());
                    userInfo.IsAuthenticated = Convert.ToBoolean(rdr["Authenticated"]);
                    userInfo.IsAccountLocked = Convert.ToBoolean(rdr["AccountLocked"]);
                }

                return userInfo;
            }
        }

        public bool IsPasswordResetLinkValid(string uid)
        {
            List<SqlParameter> paramList = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@GUID",
                        Value = uid
                    }
                };

            return new ExecuteHelper().ExecuteSP("spIsPasswordResetLinkValid", paramList);
        }

        public bool ChangeUserPassword(string uid, string newPwd)
        {
            List<SqlParameter> paramList = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@GUID",
                    Value = uid
                },
                new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = newPwd
                }
            };
            return new ExecuteHelper().ExecuteSP("spChangePassword", paramList);
        }
        public List<User> GetDropDownCities()
        {
            List<User> cities = new List<User>();

            string cs = ConfigurationManager.ConnectionStrings["VBVS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spSelectCity", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User c = new User();
                //c.CityID = (int)reader["CityID"];
                c.CityID =Convert.ToInt32(reader["CityID"]);
                c.CityName = reader["CityName"].ToString();
                cities.Add(c);
            }
            return cities;
        }
       
        public List<Admin> GetDropDownListStatus()
        {
            List<Admin> status = new List<Admin>();

            string cs = ConfigurationManager.ConnectionStrings["VBVS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spSelectStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Admin c = new Admin();
                c.SelecteStatusID = (int)reader["SelecteStatusID"];
                c.SelectStatusName = reader["SelectStatusName"].ToString();
                status.Add(c);
            }


            return status;
        }
      
        //public List<ShowBookings> ShowBookingsByStatus()
        //{
        //    //List<ShowBookings> showBook = new List<ShowBookings>();

        //    //string cs = ConfigurationManager.ConnectionStrings["VBVS"].ConnectionString;
        //    //SqlConnection con = new SqlConnection(cs);
        //    //SqlCommand cmd = new SqlCommand("spViewDetailsBystatus", con);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //con.Open();
        //    //SqlDataReader reader = cmd.ExecuteReader();
        //    //while (reader.Read())
        //    //{
        //    //    ShowBookings sb = new ShowBookings();
        //    //    sb.ShowID= (int)reader["ShowID"];
        //    //    //sb.TypeName = reader["TypeName"].ToString();
        //    //    //sb.PickUPDate =  (DateTime)reader["PickUPDate"];
        //    //    //sb.PickUpTime =(DateTime) reader["PickUpTime"];
        //    //    //sb.TravellerName = reader["TravellerName"].ToString();
        //    //    //sb.PickUpLocality = reader["PickUpLocality"].ToString();
        //    //    //sb.TravellerPhone = reader["TravellerPhone"].ToString();
        //    //    //sb.StatusAdmin = reader["StatusAdmin"].ToString();
        //    //    showBook.Add(sb);
        //    //}
        //    //return showBook;
        //}
        public DataSet GetDetailsByStatus(string SelectStatusName)
        { 
            string cs = ConfigurationManager.ConnectionStrings["VBVS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spViewDetailsBystatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Status", SelectStatusName);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        } 

    }
}
