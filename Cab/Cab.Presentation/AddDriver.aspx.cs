using MyApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_Authentication
{
    public partial class AddDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Name = txtDname.Text;
            string Address = TxtDaddress.Text;
            int WorkingCity = Convert.ToInt32(DropDownList1.SelectedValue);
            string EmailID = txtDemail.Text;
            string Username = txtDname.Text;
            string Password = txtDpass.Text;
            //string DriverPic = FileUpload1.FileName;
            if (FileUpload1.HasFile)
            {
                
                FileUpload1.SaveAs(MapPath("Images/" + FileUpload1.FileName));
               

            }
            else
            {
                FileUpload1.SaveAs("Driver1.jpg");
            }
            string DriverPic = FileUpload1.FileName;
            int TypeID = Convert.ToInt32(DropDownList2.SelectedValue);
            string CarName = txtDcarname.Text;
            string CarNumber = txtDCarNumber.Text;
            string Status = txtStatus.Text;
            DriverBusiness db = new DriverBusiness();
            if (db.InsertDriverDetails(Name, Address, WorkingCity, EmailID, Username, Password, DriverPic, TypeID, CarName, CarNumber, Status)==1)
            {
                Response.Write("<script>alert('Driver added successfully')</script>");
                
            }
            else
            {
                Response.Write("<script>alert('Driver not added, please try again')</script>");
            }

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}