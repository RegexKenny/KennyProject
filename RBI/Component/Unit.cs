using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace RBI.Component
{
    public class Unit
    {

        #region Properties Getters and Setters

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Type { get; set; }

        public string Manufacture { get; set; }

        public string RegistrationNo { get; set; }

        public string CommissionDate { get; set; }

        public string Configuration { get; set; }

        public string DesignCode { get; set; }

        public double DesignTemperatureSteam { get; set; }

        public double DesignPressureSteam { get; set; }

        public double DesignTemperatureEconomiser { get; set; }

        public double DesignPressureEconomiser { get; set; }

        public double MCR { get; set; }

        public double SteamFlow { get; set; }

        public double CostPerMWh { get; set; }

        #endregion

    }
}
