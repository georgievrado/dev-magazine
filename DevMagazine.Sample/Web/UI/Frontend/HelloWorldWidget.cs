﻿using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI;

namespace DevMagazine.Sample.Web.UI.Frontend
{
    /// <summary>
    /// Class used to create custom page widget
    /// </summary>
    /// <remarks>
    /// If this widget is a part of a Sitefinity module,
    /// you can register it in the site's toolbox by adding this to the module's Install/Upgrade method(s):
    /// initializer.Installer
    ///     .Toolbox(CommonToolbox.PageWidgets)
    ///         .LoadOrAddSection(SectionName)
    ///             .SetTitle(SectionTitle) // When creating a new section
    ///             .SetDescription(SectionDescription) // When creating a new section
    ///             .LoadOrAddWidget<HelloWorldWidget>("HelloWorldWidget")
    ///                 .SetTitle("HelloWorldWidget")
    ///                 .SetDescription("HelloWorldWidget")
    ///                 .LocalizeUsing<ModuleResourceClass>() //Optional
    ///                 .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
    ///             .Done()
    ///         .Done()
    ///     .Done();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/user-guide/widgets"/>
    public class HelloWorldWidget : SimpleView
    {
        #region Properties
        /// <summary>
        /// Gets or sets the message that will be displayed in the label.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return HelloWorldWidget.messageOnlyTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        #endregion

        #region Control References
        /// <summary>
        /// Reference to the Label control that shows the Message.
        /// </summary>
        protected virtual Label MessageLabel
        {
            get
            {
                return this.Container.GetControl<Label>("MessageLabel", true);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container"></param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container)
        {
            Label messageLabel = this.MessageLabel;
            if (string.IsNullOrEmpty(this.Message))
            {
                messageLabel.Text = "Hello, World!";
            }
            else
            {
                messageLabel.Text = this.Message;
            }
        }
        #endregion

        #region Private members & constants

        internal const string messageOnlyTemplateName = "DevMagazine.Sample.Web.UI.Frontend.HelloWorldWidget.ascx";
        internal const string headingAndMessageOnlyTemplateName = "DevMagazine.Sample.Web.UI.Frontend.HelloWorldWidgetWithHeading.ascx";

        public static readonly string messageOnlyTemplatePath = "~/HelloWorld/DevMagazine.Sample.Web.UI.Frontend.HelloWorldWidget.ascx";
        public static readonly string headingAndMessageOnlyTemplatePath = "~/HelloWorld/DevMagazine.Sample.Web.UI.Frontend.HelloWorldWidgetWithHeading.ascx";

        #endregion
    }
}
