using DevMagazine.Sample;
using DevMagazine.Sample.Web.Services;
using DevMagazine.Sample.Web.Services.ViewModels;
using DevMagazine.Sample.Web.UI.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Configuration;
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
