using Microsoft.Practices.Prism.Mvvm;
using ModuleB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB.ViewModels
{
    public class ModuleBViewModel1 : BindableBase
    {
        private Model1 selectedItem;
        public Model1 SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty<Model1>(ref selectedItem, value); }
        }

    }
}
