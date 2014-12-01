using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug2Bug.ProtectedContent
{
    public partial class Final : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Bug2Bug.Title> listbooks = new List<Bug2Bug.Title>();
            listbooks = Session["jk"] as List<Bug2Bug.Title>;

            finalGridView.DataSource = listbooks;
            finalGridView.DataBind();
        }

        protected void GoToGuessbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ProtectedContent/GuestBook");
        }
    }
}