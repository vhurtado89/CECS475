using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bug2Bug.Api
{
    public class AuthorsController : ApiController
    {
        static IAuthorService1 repo = new AuthorRepository();


        public IEnumerable<TempAuthor> getAllAuthors()
        {
     
            var authors = repo.getAllAuthors();
            return authors;
        }

        public TempAuthor getAuthor(string lname)
        {
            var author = repo.GetAuthor(lname);
            return author;
        }

        public void AddAuthor(TempAuthor auth)
        {
            repo.AddAuthor(auth);           
        }
        public void DeleteAuthor(string lname)
        {
            repo.DeleteAuthor(lname);
        }
    }
}