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
using System.Windows.Shapes;

namespace RBI
{
    /// <summary>
    /// Interaction logic for PartTypeSelector.xaml
    /// </summary>
    public partial class PartTypeSelector : Window
    {
        public PartTypeSelector()
        {
            InitializeComponent();
        }

        private void CreateUnitButton_OnClick(object sender, RoutedEventArgs e)
        {
            var addUnit = new AddUnit();
            addUnit.Show();
            Close();
        }


        private void CreateComponentButton_OnClick(object sender, RoutedEventArgs e)
        {
            var addComponent = new AddComponent();
            addComponent.Show();
            Close();
        }


        private void CreatePartButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Close();
        }

        private void CreateLevel2Button_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            Close();
        }
    }
}
