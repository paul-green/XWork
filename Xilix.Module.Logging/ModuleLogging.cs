using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;


namespace Xilix.Module.Logging
{
    [ModuleExport(typeof(ModuleLogging))]
    public class ModuleLogging : IModule
    {
        //[ImportingConstructor]
        //public ModuleLogging(CompositionContainer parentContainer)
        //{

        //}

        public void Initialize()
        {
            
        }
    }
}
