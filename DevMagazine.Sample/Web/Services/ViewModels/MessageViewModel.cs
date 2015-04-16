using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Telerik.Sitefinity.Scheduling.Model;

namespace DevMagazine.Sample.Web.Services.ViewModels
{
    [DataContract]
    public class MessageViewModel
    {
        #region Construction

        public MessageViewModel()
        {

        }

        #endregion

        #region Properties

        [DataMember]
        public string Value { get; set; }

        #endregion
    }
}
