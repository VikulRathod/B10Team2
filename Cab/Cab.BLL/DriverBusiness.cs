using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.DAL;

namespace MyApp.BLL
{
    public class DriverBusiness
    {
        DriverData DD = new DriverData();
        public int InsertDriverDetails(string Name, string Address, int WorkingCity, string EmailID, string Username, string Password, string DriverPic, int TypeID, string CarName, string CarNumber, string Status)
        {
            return DD.InsertDriverDetails(Name,Address,WorkingCity,EmailID,Username,Password,DriverPic,TypeID,CarName,CarNumber,Status);
        }
    }
}
