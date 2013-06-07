using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition.Hosting;


namespace DXWPFApplication2
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
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath="."};
        }

        //protected override void ConfigureAggregateCatalog()
        //{
        //    base.ConfigureAggregateCatalog();

        //    string dir = Environment.CurrentDirectory;
        //    DirectoryCatalog catalog = new DirectoryCatalog(".");
        //    AggregateCatalog.Catalogs.Add(catalog);
        //}



    }
}
