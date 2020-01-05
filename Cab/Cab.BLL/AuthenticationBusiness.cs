using Cab.DAL;
using Cab.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab.BLL
{
    public class AuthenticationBusiness
    {
        public User AuthenticateUser(User user)
        {
            AuthenticationData dal = new AuthenticationData();
            return dal.AuthenticateUser(user);
        }
        
        public bool IsPasswordResetLinkValid(string uid)
        {
            AuthenticationData dal = new AuthenticationData();
            return dal.IsPasswordResetLinkValid(uid);
        }

        public bool ChangeUserPassword(string uid, string newPwd)
        {
            AuthenticationData dal = new AuthenticationData();
            return dal.ChangeUserPassword(uid, newPwd);
        }
        public List<User> GetDropDownCities()
        {
            AuthenticationData dal = new AuthenticationData();
            return dal.GetDropDownCities();
        }
        public List<Admin> GetDropDownListStatus()
        {
            AuthenticationData dal = new AuthenticationData();
            return dal.GetDropDownListStatus();
        }
        //public List<ShowBookings> ShowBookingsByStatus()
        //{
        //    AuthenticationData dal = new AuthenticationData();
        //   return dal.ShowBookingsByStatus();
        //}
        public DataSet GetDetailsByStatus(string SelectStatusName)
        {
            AuthenticationData dal = new AuthenticationData();
            return dal.GetDetailsByStatus( SelectStatusName);
        }
    }
}
