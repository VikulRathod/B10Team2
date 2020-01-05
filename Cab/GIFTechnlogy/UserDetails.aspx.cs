using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GIFTechnlogy
{
    public partial class UserDetails : System.Web.UI.Page
    {

        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             BindGrid();
            }
        }
        public void BindGrid()
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                con = new SqlConnection(CS);
                con.Open();
                SqlDataAdapter adpter = new SqlDataAdapter("select * from User", con);
                DataTable dt = new DataTable();
                adpter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            con.Close();
        }

    }

}
            
