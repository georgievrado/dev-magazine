using DevMagazine.Sample;
using DevMagazine.Sample.Web.Services;
using DevMagazine.Sample.Web.Services.ViewModels;
using DevMagazine.Sample.Web.UI.Frontend;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Fluent.Pages;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Scheduling;
using Telerik.Sitefinity.Services;

namespace DevMagazine.Sample
{
    public class HelloWorldModule : ModuleBase
    {

        protected override Telerik.Sitefinity.Configuration.ConfigSection GetModuleConfig()
        {
            return null;
        }

        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);

            App.WorkWith()
                .Module(settings.Name)
                .Initialize()
                .Localization<HelloWorldModuleResources>()
                .WebService<HelloWorldService>(HelloWorldModule.HelloWorldServiceUrl);
        }

        protected void InstallToolboxConfiguration(SiteInitializer initializer)
        {
            var config = initializer.Context.GetConfig<ToolboxesConfig>();

            var pageControls = config.Toolboxes["PageControls"];
            var section = pageControls
                                      .Sections
                                      .Where<ToolboxSection>(e => e.Name == ToolboxesConfig.ContentToolboxSectionName)
                                      .FirstOrDefault();
            if (section == null)
            {
                section = new ToolboxSection(pageControls.Sections)
                {
                    Name = ToolboxesConfig.ContentToolboxSectionName,
                    Title = "ContentToolboxSectionTitle",
                    Description = "ContentToolboxSectionDescription",
                    ResourceClassId = typeof(PageResources).Name
                };
                pageControls.Sections.Add(section);
            }
            if (!section.Tools.Any<ToolboxItem>(e => e.Name == "HelloWorldWidget"))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = "HelloWorldWidget",
                    Title = "HelloWorldWidgetTitle",
                    Description = "HelloWorldWidgetDescription",
                    ResourceClassId = HelloWorldModule.ResourceClassId,
                    ModuleName = HelloWorldModule.ModuleName,
                    ControlType = typeof(HelloWorldWidget).AssemblyQualifiedName
                };
                section.Tools.Add(tool);
            }
        }

        public override void Install(Telerik.Sitefinity.Abstractions.SiteInitializer initializer)
        {
            // Here you can install a virtual path to be used for this assembly
            // A virtual path is required to access the embedded resources
            this.InstallVirtualPaths(initializer);
            this.InstallToolboxConfiguration(initializer);
        }

        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
            base.Upgrade(initializer, upgradeFrom);

            if (upgradeFrom < new Version("1.0.0.1"))
            {
                UpgradeHelloWorldModule(initializer);
            }
        } 

        private void UpgradeHelloWorldModule(SiteInitializer initializer)
        {
            var pageManager = initializer.PageManager;
            var pageName = "Hello World";
            Guid pageId = Guid.NewGuid();

            var template = pageManager.GetTemplates().Where(t => t.Title == "Base").FirstOrDefault();

            var pageNode = pageManager.CreatePage(PageLocation.Frontend, pageId, NodeType.Standard);
            if (pageNode != null)
            {
                var pageData = pageNode.GetPageData();

                pageData.Culture = Thread.CurrentThread.CurrentCulture.ToString();
                pageData.HtmlTitle = pageName;
                pageData.Template = template;

                pageNode.Title = pageName;
                pageNode.Name = pageName;
                pageNode.Description = pageName;
                pageNode.UrlName = Regex.Replace(pageName.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                pageNode.ShowInNavigation = true;
                pageNode.DateCreated = DateTime.Now;
                pageNode.LastModified = DateTime.Now;
                pageNode.ApprovalWorkflowState = "Published";

                pageManager.Provider.SuppressSecurityChecks = true;
                var pageDataId = pageManager.GetPageNode(pageId).PageId;
                var page = pageManager.EditPage(pageDataId, CultureInfo.CurrentUICulture);

                var helloWorldWidget = new HelloWorldWidget();

                var helloWorldWidgetControl = pageManager.CreateControl<PageDraftControl>(helloWorldWidget, "TA6C74962009_Col00");
                helloWorldWidgetControl.Caption = "HelloWorldWidget";
                pageManager.SetControlDefaultPermissions(helloWorldWidgetControl);
                page.Controls.Add(helloWorldWidgetControl);

                //publishes draft page
                pageManager.PublishPageDraft(page, CultureInfo.CurrentUICulture);
            }
        }

        public override void Uninstall(SiteInitializer initializer)
        {
            base.Uninstall(initializer);
        }

        public override Guid LandingPageId
        {
            get { return Guid.Empty; }
        }

        public override Type[] Managers
        {
            get { return null; }
        }

        #region Virtual paths
        /// <summary>
        /// Installs module virtual paths.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallVirtualPaths(SiteInitializer initializer)
        {
            // Here you can register your module virtual paths

            var virtualPaths = initializer.Context.GetConfig<VirtualPathSettingsConfig>().VirtualPaths;
            var moduleVirtualPath = HelloWorldModule.ModuleVirtualPath + "*";
            if (!virtualPaths.ContainsKey(moduleVirtualPath))
            {
                virtualPaths.Add(new VirtualPathElement(virtualPaths)
                {
                    VirtualPath = moduleVirtualPath,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = typeof(HelloWorldModule).Assembly.GetName().Name
                });
            }
        }
        #endregion

        #region Fields and Constants

        public const string ModuleName = "HelloWorld";
        public const string ModuleTitle = "Hello World";
        public const string ModuleDescription = "Hello World module";
        public const string ModuleVirtualPath = "~/HelloWorld/";

        public static readonly string ResourceClassId = typeof(HelloWorldModuleResources).Name;

        public const string HelloWorldServiceUrl = "Sitefinity/Services/DevMagazine/HelloWorldService.svc/";

        #endregion
    }
}
