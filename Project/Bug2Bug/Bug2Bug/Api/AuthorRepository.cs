using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Http;
using System.ServiceModel;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Bug2Bug.Api
{
    public class AuthorRepository : IAuthorService1
    {
        public IEnumerable<TempAuthor> getAllAuthors()
        {    
     
            using(BooksEntities tmp = new BooksEntities())
            {
                List<Author> auths = tmp.Authors.ToList();
                var tmpAuths = auths.Select(x => new TempAuthor() { ID = x.AuthorID, fName = x.FirstName, lName = x.LastName })
                    .ToList();
                return tmpAuths;
            }
        }
        public TempAuthor GetAuthor(string lname)
        {
            try
            {
                TempAuthor singleTemp = new TempAuthor();
                using(BooksEntities tmp = new BooksEntities())
                {
                    var singleAuth = tmp.Authors.FirstOrDefault(x => x.LastName.Equals(lname));
                    singleTemp.ID = singleAuth.AuthorID;
                    singleTemp.fName = singleAuth.FirstName;
                    singleTemp.fName = singleAuth.LastName;

                    return singleTemp;
                }
            }
            catch
            {
                throw new FaultException("This is bad");
            }

        }
        public void AddAuthor(TempAuthor auth)
        {          
                using (BooksEntities tmp = new BooksEntities())
                {
                    
                    Author author = new Author { FirstName = auth.fName, LastName = auth.lName };
                    tmp.Authors.Add(author);
                    tmp.SaveChanges();
                }
          

        }
        public void DeleteAuthor(string lname)
        {
            try
            {
                using (BooksEntities tmp = new BooksEntities())
                {
                    var singleAuth = tmp.Authors.FirstOrDefault(x => x.LastName.Equals(lname));
                    tmp.Authors.Remove(singleAuth);
                    tmp.SaveChanges();
                }
            }
            catch
            {

            }
        }
    }
}