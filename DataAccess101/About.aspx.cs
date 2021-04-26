using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccess101
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from HumanResources.Department";
                    cmd.CommandType = System.Data.CommandType.Text;
                    //con.Open();
                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    if (reader.Read())
                    //    {
                    //        TextBox1.Text = TextBox1.Text + reader.GetValue(0);
                    //        TextBox2.Text = TextBox2.Text + reader.GetValue(1);
                    //    }
                    //}
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}