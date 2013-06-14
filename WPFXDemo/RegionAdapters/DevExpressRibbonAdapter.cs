using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Ribbon;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;

namespace WPFXilix.RegionAdapters
{
    [Export]
    public class DevExpressRibbonAdapter : RegionAdapterBase<RibbonControl>
    {
        [ImportingConstructor]
        public DevExpressRibbonAdapter(IRegionBehaviorFactory behaviorFactory):base(behaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, RibbonControl regionTarget)
        {
            
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
