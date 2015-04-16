using DevMagazine.Sample.Web.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Scheduling;
using Telerik.Sitefinity.Web.Services;

namespace DevMagazine.Sample.Web.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HelloWorldService : IHelloWorldService
    {
        public MessageViewModel GetMessage()
        {
            return new MessageViewModel() { Value = "Hello world!" };
        }
    }
}
