using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MyApp.Models;
using Cab.Models;

namespace _1_Authentication
{
    public partial class addtype : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {           
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Request.QueryString["Id"]);        
                }
            }
            LoadControls();

        }
        void LoadControls()
        {
            CityDBContext db = new CityDBContext();
            List<addCityNames> cities = db.addCityNames.ToList();
            foreach (addCityNames city in cities)
            {
                ListItem li = new ListItem(city.Name, city.Id.ToString());
                ddlClass.Items.Add(li); 
            }
            ListItem lii = new ListItem("--Select City--","-1");
            ddlClass.Items.Insert(0,lii);       
            }

        protected void btnAddType_Click(object sender, EventArgs e)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand("usp_addType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TypeName", txtCarType.Text);
                cmd.Parameters.AddWithValue("@CityID", ddlClass.SelectedValue);
                cmd.Parameters.AddWithValue("@MinBillCharge", txtMinBillCharge.Text);
                cmd.Parameters.AddWithValue("@FreeKms", txtFreeKMs.Text);
                cmd.Parameters.AddWithValue("@WaitingCharges", txtWatCharge.Text);
                cmd.Parameters.AddWithValue("@Charge", txtExtraPerCharge.Text);
                con.Open();
                int ans = cmd.ExecuteNonQuery();

                if (ans != 0)
                {
                    Response.Write("data inserted Successfully");
                }
                else
                {
                    Response.Write("data not inserted Successfully");
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }

   
           

            }
        }
  

}
    
   
