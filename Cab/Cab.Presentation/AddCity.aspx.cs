using Cab.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_Authentication
{
    public partial class AddCity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCity();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string city = txtCityName.Text;
            AdminBusiness ab = new AdminBusiness();
            if (ab.InsertCity(city) == 1)
            {
                Response.Write("<script>alert('City added successfully')</script>");
                ShowCity();
            }
            else
            {
                Response.Write("<script>alert('City not added, please try again')</script>");
            }
        }

        protected void ShowCity()
        {
            AdminBusiness ab = new AdminBusiness();
            DataSet ds = ab.CityRecord();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                string CityName = row.Cells[2].Text;

                AdminBusiness ab = new AdminBusiness();
                ab.DeleteCity(CityName);
            }
            catch (Exception e1)
            {
                Response.Write("<script>alert('No City to Delete')</script>");
            }
            finally
            {
                ShowCity();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AdminBusiness ab = new AdminBusiness();
            GridView1.EditIndex = e.NewEditIndex;
            ab.CityRecord();
            ShowCity();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            AdminBusiness ab = new AdminBusiness();
            ab.CityRecord();
            ShowCity();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            //int CityId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            //TextBox CityName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCity");
            //string CityName = (row.FindControl("txtCity") as TextBox).Text;

            int CityId = Convert.ToInt32(((TextBox)row.Cells[1].Controls[0]).Text);
            string City = ((TextBox)row.Cells[2].Controls[0]).Text;

            AdminBusiness ab = new AdminBusiness();
            ab.UpdateCity(CityId, txtCityName.Text);
            GridView1.EditIndex = -1;
            ab.CityRecord();
            ShowCity();
        }
    }
}