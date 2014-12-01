using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug2Bug.Api
{
    public partial class _default : System.Web.UI.Page
    {
        AuthorsController tmp = new AuthorsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var auths = tmp.getAllAuthors();
                Authors_GridView.DataSource = auths;
                Authors_GridView.DataBind();
            }

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            TempAuthor newAuth = new TempAuthor
            {
                fName = fname.Text,
                lName = lname.Text
            };

            tmp.AddAuthor(newAuth);
            var auths = tmp.getAllAuthors();
            Authors_GridView.DataSource = auths;
            Authors_GridView.DataBind();          

        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            List<TempAuthor> x = new List<TempAuthor>();
            TempAuthor auth = tmp.getAuthor(authorSearch.Text);
            x.Add(auth);
            Authors_GridView.DataSource = x;
            Authors_GridView.DataBind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            tmp.DeleteAuthor(authorDelete.Text);

            var auths = tmp.getAllAuthors();
            Authors_GridView.DataSource = auths;
            Authors_GridView.DataBind();
        }
    }
}