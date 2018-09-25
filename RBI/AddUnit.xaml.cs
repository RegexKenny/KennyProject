using System;
using System.IO;
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
using RBI.Component;
using SQLite;

namespace RBI
{
    /// <summary>
    /// Interaction logic for AddUnit.xaml
    /// </summary>
    public partial class AddUnit : Window
    {
        public AddUnit()
        {
            InitializeComponent();
        }

        private void AddUnitSaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var unit = new Unit();

            try
            {
                unit.Type = UnitType.Text;
                unit.Manufacture = UnitManufacture.Text;
                unit.RegistrationNo = UnitRegistrationNo.Text;
                unit.CommissionDate = UnitCommissionDate.Text;
                unit.Configuration = UnitConfiguration.Text;
                unit.DesignCode = UnitDesignCode.Text;
                unit.DesignTemperatureSteam = double.Parse(UnitDesignTempSteam.Text);
                unit.DesignPressureSteam = double.Parse(UnitDesignPreSteam.Text);
                unit.DesignTemperatureEconomiser = double.Parse(UnitDesignTempEconomiser.Text);
                unit.DesignPressureEconomiser = double.Parse(UnitDesignPreEconomiser.Text);
                unit.MCR = double.Parse(UnitMCR.Text);
            }
            catch (ArgumentException)
            {
                //Do somthing
                //The input is null
            }
            catch (FormatException)
            {
                //Do somthing
                //The input is not in proper formate
            }
            catch (OverflowException)
            {
                //do somthing
                //The input is out of range
            }

            using (var connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Unit>();
                connection.Insert(unit);
            };

            Close();
        }
    }
}
