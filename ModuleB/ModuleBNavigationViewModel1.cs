using Common.Events;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB
{
    public class ModuleBNavigationViewModel1 : BindableBase
    {
        private EventAggregator _eventAggregator;

        public ModuleBNavigationViewModel1()
        {
            Title = "Module B View 1";
            InvokeView1Cmd = new DelegateCommand<object>(invokeView1Method, canIvokeInvokeView1Method);
            _eventAggregator = (EventAggregator)ServiceLocator.Current.GetInstance(typeof(IEventAggregator));
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                SetProperty(ref this.title, value);
            }
        }

        public DelegateCommand<object> InvokeView1Cmd
        {
            get; private set;
        }

        private void invokeView1Method(object obj)
        {
            this._eventAggregator?.GetEvent<NotifyOtherModulesEvent>()?.Publish(null);
            //IRegionManager rm = (IRegionManager)ServiceLocator.Current.GetInstance(typeof(IRegionManager));
            ////rm.AddToRegion(Regions.NAVIGATION, new ModuleBView1());
            //rm.Regions[Regions.MAIN].Activate(ServiceLocator.Current.GetInstance(typeof(Views.ModuleBView1)));

            //IRegionManager rm = (IRegionManager)ServiceLocator.Current.GetInstance(typeof(IRegionManager));
            //var container = (IUnityContainer)ServiceLocator.Current.GetInstance(typeof(IUnityContainer));
            //rm.Regions["Main"].Activate(container.Resolve<ModuleBNavigationView1>());

        }

        private bool canIvokeInvokeView1Method(object obj) { return true; }
    }
}
