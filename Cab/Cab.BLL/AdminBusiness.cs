using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cab.BLL;
using Cab.DAL;
using System.Data;

namespace Cab.BLL
{
    public class AdminBusiness
    {
        AdminData ad = new AdminData();
        public int InsertCity(string city)
        {
            return ad.InsertCity(city);
        }

        public DataSet CityRecord()
        {
            return ad.CityRecord();
        }

        public void DeleteCity(string CityName)
        {
            ad.DeleteCity(CityName);
        }

        public void UpdateCity(int id,string city)
        {
            ad.UpdateCity(id,city);
        }
    }
}
