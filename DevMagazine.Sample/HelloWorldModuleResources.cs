using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace DevMagazine.Sample
{
    /// <summary>
    /// Localizable strings for the Tasks module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<HelloWorldModuleResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("HelloWorldModuleResources", ResourceClassId = "HelloWorldModuleResources", Title = "HelloWorldModuleResourcesTitle", TitlePlural = "HelloWorldModuleResourcesTitlePlural", Description = "HelloWorldModuleResourcesDescription")]
    public class HelloWorldModuleResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="HelloWorldModuleResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public HelloWorldModuleResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="HelloWorldModuleResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public HelloWorldModuleResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// Tasks Resources
        /// </summary>
        [ResourceEntry("HelloWorldModuleResourcesTitle",
            Value = "Hello World module labels",
            Description = "The title of this class.",
            LastModified = "2014/08/04")]
        public string HelloWorldModuleResourcesTitle
        {
            get
            {
                return this["HelloWorldModuleResourcesTitle"];
            }
        }

        /// <summary>
        /// Tasks Resources Title plural
        /// </summary>
        [ResourceEntry("HelloWorldModuleResourcesTitlePlural",
            Value = "Hello World module labels",
            Description = "The title plural of this class.",
            LastModified = "2014/08/04")]
        public string HelloWorldModuleResourcesTitlePlural
        {
            get
            {
                return this["HelloWorldModuleResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for Tasks module.
        /// </summary>
        [ResourceEntry("HelloWorldModuleResourcesDescription",
            Value = "Contains localizable resources for Hello World module.",
            Description = "The description of this class.",
            LastModified = "2014/08/04")]
        public string HelloWorldModuleResourcesDescription
        {
            get
            {
                return this["HelloWorldModuleResourcesDescription"];
            }
        }
        #endregion

        #region Toolbox

        [ResourceEntry("HelloWorldWidgetTitle",
            Value = "Hello World",
            Description = "The title of the HelloWorldWidget control, that appears on the controls toolbox.",
            LastModified = "2012/01/28")]
        public string HelloWorldWidgetTitle
        {
            get
            {
                return this["HelloWorldWidgetTitle"];
            }
        }

        [ResourceEntry("HelloWorldWidgetDescription",
            Value = "Hello World Message",
            Description = "The description of the HelloWorldWidget control, that appears on the controls toolbox.",
            LastModified = "2012/01/28")]
        public string HelloWorldWidgetDescription
        {
            get
            {
                return this["HelloWorldWidgetDescription"];
            }
        }
        #endregion
    }
}
