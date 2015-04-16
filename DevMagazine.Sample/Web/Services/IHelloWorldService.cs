using DevMagazine.Sample.Web.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Telerik.Sitefinity.Utilities.MS.ServiceModel.Web;
using Telerik.Sitefinity.Web.Services;

namespace DevMagazine.Sample.Web.Services
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        /// <summary>
        /// Gets the SalesForce account.
        /// </summary>
        /// <param name="name">The name of the SalesForce account.</param>
        [WebHelp(Comment = "Gets hello world message")]
        [WebGet(UriTemplate = "/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        MessageViewModel GetMessage();
    }
}
