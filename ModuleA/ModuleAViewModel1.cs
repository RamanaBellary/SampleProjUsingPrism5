using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Events;

namespace ModuleA
{
    public class ModuleAViewModel1:BindableBase
    {
        private EventAggregator _eventAggregator;
        public ModuleAViewModel1()
        {
            Title = "Module A View 1";

            _eventAggregator = (EventAggregator)ServiceLocator.Current.GetInstance(typeof(IEventAggregator));

            this._eventAggregator?.GetEvent<NotifyOtherModulesEvent>()?.Subscribe(NotifyOtherModulesEvent);
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

        private void NotifyOtherModulesEvent(object obj) { }
    }
}
