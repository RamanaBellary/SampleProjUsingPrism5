using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    //[ModuleDependency("ModuleB")]
    public class ModuleA : IModule
    {
        public void Initialize()
        {
            IUnityContainer container = (IUnityContainer)ServiceLocator.Current.GetInstance(typeof(IUnityContainer));
            container.RegisterType<ModuleAViewModel1>();
            //container.RegisterType<ModuleAViewModel1>(new ContainerControlledLifetimeManager());
            IRegionManager regionManager = (IRegionManager)ServiceLocator.Current.GetInstance(typeof(IRegionManager));
            regionManager.Regions[Shared.Regions.NAVIGATION].Add(new ModuleAView1());
        }
    }
}
