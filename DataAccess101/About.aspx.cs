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
            using (IDbConnection con = new SqlConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = (SqlConnection)con;
                    cmd.CommandText = "Select * from HumanResources.Department where DepartmentID = @ID";
                    //cmd.Parameters.Add(new SqlParameter("@ID", 4));
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@ID";
                    param.Value = 4;
                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //GridView1.DataSource = reader;
                        while (reader.Read())
                        {
                            TextBox1.Text = TextBox1.Text + reader["Name"];
                            TextBox2.Text = TextBox2.Text + reader["GroupName"];
                        }
                    }
                    //using (SqlDataAdapter adapter = new SqlDataAdapter())
                    //{
                    //    adapter.SelectCommand = cmd;
                    //    DataSet ds = new DataSet();
                    //    adapter.Fill(ds);
                    //    GridView1.DataSource = ds.Tables[0];
                    //    GridView1.DataBind();
                    //}
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}