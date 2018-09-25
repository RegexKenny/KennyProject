using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SQLite;
using RBI.Component;

namespace RBI
{
    /// <summary>
    /// Interaction logic for BasicAttributes.xaml
    /// </summary>
    public partial class AddComponent : Window
    {
        private readonly List<Component.Component> _componentList = new List<Component.Component>();

        public AddComponent()
        {
            InitializeComponent();

        }

        private void AddComponentSaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var component = new Component.Component();

            try
            {
                component.Type = ComponentType.Text;
                component.Material = ComponentMaterial.Text;
                component.OutsideDiameter = double.Parse(ComponentOutsideDiamiter.Text);
                component.MinWallThickness = double.Parse(ComponentMinWT.Text);
                component.ActualWallThickness = double.Parse(ComponentActualWT.Text);
                component.DesignTemperature = double.Parse(ComponentDesignTemp.Text);
                component.DesignPressure = double.Parse(ComponentDesignPre.Text);
                component.OperatingTemperature = double.Parse(ComponentOperatingTemp.Text);
                component.OperatingPressure = double.Parse(ComponentOperatingPre.Text);
                component.CodeMinWallThickness = double.Parse(ComponentCodeMinWT.Text);
                component.WaterStream = ComponentWaterStream.Text;
            }
            catch (Exception)
            {
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Component.Component>();
                connection.Insert(component);
            };

            Close();  
        }
    }
}
