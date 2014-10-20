/*
 * Form1.cs
 * 
 * Has all the queries that are being displayed
 * 
 */
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

 

namespace Assignment4._2
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
          
        }
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

        private void DisplayAuthorsTable_Load(object sender, EventArgs e)
        {
            var authorsAndTitles =
                 from book in dbcontext.Titles
                 from author in book.Authors
                 orderby book.Title1
                 select new { book.Title1, author.FirstName, author.LastName };

            outputTextBox.AppendText("\r\nTitles and Authors \n");
            foreach (var authAndTitles in authorsAndTitles)
            {
                outputTextBox.AppendText(String.Format("{0,-10}:  {1, -5}, {2}\n", authAndTitles.Title1, authAndTitles.FirstName, authAndTitles.LastName));
            }


            var authorsAndTitlesByName =
                from book in dbcontext.Titles
                from author in book.Authors
                orderby book.Title1,author.LastName, author.FirstName
                select new { book.Title1, author.FirstName, author.LastName };

            outputTextBox.AppendText("\r\nAuthors and titles with authors sorted for each title \n");

            foreach (var authAndTitles in authorsAndTitlesByName)
            {
                outputTextBox.AppendText(String.Format("{0,-10}:  {1, -5} {2}\n", authAndTitles.Title1, authAndTitles.FirstName, authAndTitles.LastName));
            }
           
            var authorsByTitle =
                from books in dbcontext.Titles
                orderby books.Title1
                select new
                {
                    Name = books.Title1,
                    Authors =
                        from author in books.Authors
                        orderby author.LastName
                        select new { author.FirstName, author.LastName }
                };
            
            outputTextBox.AppendText("\r\n\n\nThe titles, grouped by authors.\n\n");

            foreach (var theTitles in authorsByTitle)
            {
                outputTextBox.AppendText(String.Format("{0}:\n",theTitles.Name));
                foreach (var theAuthors in theTitles.Authors) 
                {
                    outputTextBox.AppendText(String.Format("     {0}, {1} \n\n", theAuthors.FirstName,theAuthors.LastName));
                }
            }
               

        }


    }
 
}
