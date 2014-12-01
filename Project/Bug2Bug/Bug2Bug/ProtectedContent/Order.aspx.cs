using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug2Bug.ProtectedContent
{
    public partial class Order : System.Web.UI.Page
    {
        // Entity Framework DbContext
        BooksEntities dbcontext = new BooksEntities();        

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Bug2Bug.Title> listbooks = new List<Bug2Bug.Title>();
            listbooks = Session["jk"] as List<Bug2Bug.Title>;

            orderListBox.DataSource = listbooks;
            orderListBox.DataBind();
        }

        string theISBN = "";
        protected void ListBox1_GetISBN(object sender, EventArgs e)
        {
            IEnumerator ie = orderListBox.Items.GetEnumerator();

            while (ie.MoveNext())
            {
                ListItem li = (ListItem)ie.Current;
                theISBN = li.Value;
            }
        }

        // THIS IS KINDA CORRECT.
        protected void ListBox1_RemoveFromCart(object sender, EventArgs e)
        {
            List<Bug2Bug.Title> listbooks = new List<Bug2Bug.Title>();
            if (Session["jk"] == null)
            {
                Session["jk"] = listbooks;
            }
            else
            {
                listbooks = Session["jk"] as List<Bug2Bug.Title>;
            }

            if (listbooks.Any())
            {
                dbcontext.Titles.Load(); // load Authors table into memory

                // query to get the book
                var titleQuery =
                   from book in dbcontext.Titles.Local
                   where book.ISBN == theISBN
                   select book;

                Bug2Bug.Title titletemp = new Bug2Bug.Title();

                titletemp.ISBN = titleQuery.First().ISBN;
                titletemp.Title1 = titleQuery.First().Title1;
                titletemp.Copyright = titleQuery.First().Copyright;
                titletemp.EditionNumber = titleQuery.First().EditionNumber;
                titletemp.Price = titleQuery.First().Price;

                var toRemove = (listbooks.Single(r => r.ISBN == titletemp.ISBN));
                listbooks.Remove(toRemove);

                Session["jk"] = listbooks;
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void ListBox1_EmptyCart(object sender, EventArgs e)
        {
            // Remove everything from the list....
            List<Bug2Bug.Title> listbooks = new List<Bug2Bug.Title>();
            if (Session["jk"] == null)
            {
                Session["jk"] = listbooks;
            }
            else
            {
                listbooks = Session["jk"] as List<Bug2Bug.Title>;
            }

            listbooks.Clear();
            Session["jk"] = listbooks;
        }

        protected void GoToBooks(object sender, EventArgs e)
        {
            Response.Redirect("~/ProtectedContent/Books");
        }

        protected void CheckOutOrder(object sender, EventArgs e)
        {
            Response.Redirect("~/ProtectedContent/Checkout");
        }
    }
}