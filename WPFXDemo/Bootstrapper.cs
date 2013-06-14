using Microsoft.Practices.Prism.MefExtensions;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using WPFXilix.RegionAdapters;
using DevExpress.Xpf.Ribbon;
using System.Reflection;


namespace WPFXilix
{
    class Bootstrapper : MefBootstrapper
    {

        protected override System.Windows.DependencyObject CreateShell()
        {
            return new MainWindow();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Window mainWindow = this.Shell as Window;
            Application.Current.MainWindow = mainWindow;

            mainWindow.Show();

        }


        

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Because we created the CallbackLogger and it needs to be used immediately, we compose it to satisfy any imports it has.
          this.Container.ComposeExportedValue<CompositionContainer>(this.Container);

        //  this.Container.ComposeExportedValue<DevExpressRibbonAdapter>();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            //Scan the current assembly for Export types and register in the container
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        } 




        protected override IModuleCatalog CreateModuleCatalog()
        {
            //Scan the current folder for modules (ModuleExport)
            return new DirectoryModuleCatalog() { ModulePath="."};
        }


        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            // Call base method
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings == null) return null;

            
            var t = base.Container.GetExport<DevExpressRibbonAdapter>();
            mappings.RegisterMapping(typeof(RibbonControl), t.Value);

            // Set return value
            return mappings;
        }


    }
}
