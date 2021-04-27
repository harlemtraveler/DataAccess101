using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccess101
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdventureWorks2019Entities context = new AdventureWorks2019Entities();
            var results = context.Departments.ToList();
            GridView1.DataSource = results;
            GridView1.DataBind();

        }
    }
}