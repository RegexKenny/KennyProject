using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using SQLite;
using RBI.Component;

namespace RBI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        PartViewModel vm = new PartViewModel();

        public MainWindow()
        {
            DataContext = vm;
            vm.LoadData();
            InitializeComponent();           
        }

        private void NewButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var partTypeSelector = new PartTypeSelector();
            partTypeSelector.ShowDialog();
        }

    }
}
