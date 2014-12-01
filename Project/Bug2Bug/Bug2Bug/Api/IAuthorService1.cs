using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Bug2Bug.Api
{
    [ServiceContract]
    interface IAuthorService1
    {
        //[OperationContract]
        //[WebGet]
        IEnumerable<TempAuthor> getAllAuthors();

        //[OperationContract]
        //[WebInvoke(UriTemplate="Authors/AddAuthor/{fname}/{lname}")]
        void AddAuthor(TempAuthor auth);

        //[OperationContract]
        //[WebGet(UriTemplate = "Authors/GetAuthor/{lname}")]
        TempAuthor GetAuthor(string lname);      

        //[OperationContract]
        //[WebInvoke(UriTemplate = "Authors/DeleteAuthor/{lname}")]
        void DeleteAuthor(string lname);
    }
}
