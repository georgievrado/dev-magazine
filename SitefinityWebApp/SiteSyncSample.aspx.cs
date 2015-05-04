using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Events.Model;
using Telerik.Sitefinity.SiteSync;

namespace SitefinityWebApp
{
    public partial class SiteSyncSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            App.WorkWith().SiteSync().SelectTarget("destination-site-url.com").SetSites(new string[] { "Site A" }).Sync(new string[] { typeof(Event).FullName });
        }
    }
}