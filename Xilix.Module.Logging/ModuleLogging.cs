using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using System.Runtime.CompilerServices;
using Microsoft.Practices.Prism.Regions;


namespace Xilix.Module.Logging
{
    [ModuleExport(typeof(ModuleLogging))]
    public class ModuleLogging : IModule
    {

        public ModuleLogging(IRegionManager regionManager)
        {

        }

     
        public void Initialize()
        {
            
        }
    }
}
