using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class NotifyOtherModulesEvent : PubSubEvent<object> { }
}
