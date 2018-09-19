using Shared;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ModuleB.Views;
using ModuleB.ViewModels;

namespace ModuleB
{
    public class ModuleB : IModule
    {
        public void Initialize()
        {
            var container = (IUnityContainer)ServiceLocator.Current.GetInstance(typeof(IUnityContainer));
            //container.RegisterType<ModuleBNavigationView1>();
            container.RegisterType<ModuleBNavigationViewModel1>();
            container.RegisterType<ModuleBView1>();
            container.RegisterType<ModuleBViewModel1>();
            IRegionManager rm = (IRegionManager)ServiceLocator.Current.GetInstance(typeof(IRegionManager));
            //rm.AddToRegion(Regions.NAVIGATION, new ModuleBView1());
            rm.Regions[Regions.NAVIGATION].Add(new ModuleBNavigationView1());
            //rm.Regions[Regions.MAIN].Add(new ModuleBView1());
            rm.RegisterViewWithRegion("Main", typeof(ModuleBView1));
        }
    }
}
