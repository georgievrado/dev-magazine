using DevMagazine.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Services;

namespace DevMagazine.Sample
{
    public static class HelloWorldModuleInstaller
    {
        #region Public methods
        /// <summary>
        /// Called before the application start.
        /// </summary>
        public static void PreApplicationStart()
        {
            Bootstrapper.Initialized += HelloWorldModuleInstaller.OnBootstrapperInitialized;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Called when the Bootstrapper is initialized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Telerik.Sitefinity.Data.ExecutedEventArgs" /> instance containing the event data.</param>
        private static void OnBootstrapperInitialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                // We have to register the module at a very early stage when sitefinity is initializing
                HelloWorldModuleInstaller.RegisterModule();
            }
        }

        /// <summary>
        /// Registers the ContentWiki module.
        /// </summary>
        private static void RegisterModule()
        {
            var configManager = ConfigManager.GetManager();
            var modulesConfig = configManager.GetSection<SystemConfig>().ApplicationModules;
            if (!modulesConfig.Elements.Any(el => el.GetKey().Equals(HelloWorldModule.ModuleName)))
            {
                modulesConfig.Add(HelloWorldModule.ModuleName, new AppModuleSettings(modulesConfig)
                {
                    Name = HelloWorldModule.ModuleName,
                    Title = HelloWorldModule.ModuleTitle,
                    Description = HelloWorldModule.ModuleDescription,
                    Type = typeof(HelloWorldModule).AssemblyQualifiedName,
                    StartupType = StartupType.OnApplicationStart
                });

                configManager.SaveSection(modulesConfig.Section);
            }
        }
        #endregion
    }
}
