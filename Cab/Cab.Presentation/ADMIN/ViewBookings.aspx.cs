using Cab.BLL;
using Cab.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_Authentication.ADMIN
{
    public partial class ViewBookings : System.Web.UI.Page
    {
        AuthenticationBusiness bll = new AuthenticationBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { BindDataToDropDpownList(); }
        }
        void BindDataToDropDpownList()
        {
            List<User> cities = bll.GetDropDownCities();
            foreach (User c in cities)
            {
                ListItem li = new ListItem(c.CityName, c.CityID.ToString());
                DropDownList1.Items.Add(li);
            }
            ListItem li2 = new ListItem("--Select City--", "-1");
            DropDownList1.Items.Insert(0, li2);


            List<Admin> status = bll.GetDropDownListStatus();
            foreach (Admin  a in status)
            {
                ListItem li3 = new ListItem( a.SelectStatusName, a.SelecteStatusID.ToString());
                DropDownList2.Items.Add(li3);
            }
            ListItem li4 = new ListItem("--Select Status--", "-1");
            DropDownList2.Items.Insert(0, li4);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // User Code
          //if(  DateTime.Today >= Calendar1.SelectedDate.Date)
          //  {
          //      Label1.Text="Do not Enter Previous date than today";
          //  }

        }
        //void ToGetBookings()
        //{
        //    bll.ShowBookingsByStatus();
        //    if (DropDownList1.SelectedItem ==DropDownList2.SelectedItem==Calendar1.Enabled )
        //    {
        //        Label1.Text = "Bookings are:";

        //        //Here we write one methode or call it 
        //    }
        //    else
        //    {
        //        Label1.Text = "No Bookings";
        //    }
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string SelectStatusName = (DropDownList2.SelectedValue);
                DataSet ds = bll.GetDetailsByStatus(SelectStatusName);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

                if (DropDownList2.SelectedIndex == 1 || DropDownList2.SelectedIndex == 2)
                {
                    GridView1.Columns[7].Visible = false;
                }
                else
                {
                    GridView1.Columns[7].Visible = true;
                }
            }

        }
   
        protected void SqlDataSource2_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows == 0)
            {
                Label1.Text = "No bookings";

            }
            else
            {
                Label1.Text = "";
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}