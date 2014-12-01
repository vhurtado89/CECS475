using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Bug2Bug.ProtectedContent
{
    public partial class GuestBook : System.Web.UI.Page
    {
        GuessBooksEntities1 dbcontext = new GuessBooksEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dbcontext.Guesses.Load();
                var allEntries =  from guess in dbcontext.Guesses.Local
                                  orderby guess.Id select guess;
                GuessBook_GridView.DataSource = allEntries;
                GuessBook_GridView.DataBind();
            }

        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Guess newEntry = new Guess
            {
                Name = Name.Text,
                Email = Email.Text,
                Message = Message.Text
            };
            
            dbcontext.Guesses.Add(newEntry);
            dbcontext.SaveChanges();
            dbcontext.Guesses.Load();
            var allEntries = from guess in dbcontext.Guesses.Local
                             orderby guess.Id
                             select guess;
            GuessBook_GridView.DataSource = allEntries;
            GuessBook_GridView.DataBind();
     }

     

    }
}