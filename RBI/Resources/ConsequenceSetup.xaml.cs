using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using SQLite;

namespace RBI.Resources
{
    /// <summary>
    /// Interaction logic for ConsequenceSetup.xaml
    /// </summary>
    public partial class ConsequenceSetup : ResourceDictionary
    {
        public ConsequenceSetup()
        {
            InitializeComponent();
        }

        private void ConsequenceButton_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = new PartViewModel();
            vm.UpdateData();
        }
    }
}
