using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug2Bug.ProtectedContent
{
    public partial class Checkout : System.Web.UI.Page
    {

        // Entity Framework DbContext
        BooksEntities dbcontext = new BooksEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Bug2Bug.Title> listbooks = new List<Bug2Bug.Title>();
            listbooks = Session["jk"] as List<Bug2Bug.Title>;

            checkoutListBox.DataSource = listbooks;
            checkoutListBox.DataBind();
        }

        protected void ReturnToCart(object sender, EventArgs e)
        {
            Response.Redirect("~/ProtectedContent/Order");
        }
        protected void ContinueShopping(object sender, EventArgs e)
        {
            Response.Redirect("~/ProtectedContent/Books");
        }
        protected void FinalizeOrder(object sender, EventArgs e)
        {
            Response.Redirect("~/ProtectedContent/Final");
        }
    }
}