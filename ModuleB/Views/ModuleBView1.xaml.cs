using Microsoft.Practices.ServiceLocation;
using ModuleB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModuleB.Views
{
    /// <summary>
    /// Interaction logic for ModuleBView1.xaml
    /// </summary>
    public partial class ModuleBView1 : UserControl
    {
        public ModuleBView1()
        {
            InitializeComponent();
            this.DataContext = ServiceLocator.Current.GetInstance<ModuleBViewModel1>();
        }
    }
}
