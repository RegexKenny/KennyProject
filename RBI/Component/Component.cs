using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using RBI.Annotations;
using RBI.ConsequenceAndRisk;
using SQLite;

namespace RBI.Component
{
    public class Component : Consequence, INotifyPropertyChanged
    {
        private string _material;
        private double _outsideDiameter;
        private double _minWallThickness;
        private double _actualWallThickness;
        private double _codeMinWallThickness;
        private double _designTemperature;
        private double _designPressure;
        private double _operatingPressure;
        private double _operatingTemperature;
        private string _waterStream;
        public event PropertyChangedEventHandler PropertyChanged;

        #region Basic Properties Getters and Setters

        [PrimaryKey]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public string Material
        {
            get => _material;
            set
            {
                _material = value;
                OnPropertyChanged("Material");
            }
        }

        public double OutsideDiameter
        {
            get => _outsideDiameter;
            set
            {
                _outsideDiameter = value;
                OnPropertyChanged("OutsideDiameter");
            }
        }

        public double MinWallThickness
        {
            get => _minWallThickness;
            set
            {
                _minWallThickness = value;
                OnPropertyChanged("MinWallThickness");
            }
        }

        public double ActualWallThickness
        {
            get => _actualWallThickness;
            set
            {
                _actualWallThickness = value;
                OnPropertyChanged("ActualWallThickness");
            }
        }

        public double CodeMinWallThickness
        {
            get => _codeMinWallThickness;
            set
            {
                _codeMinWallThickness = value;
                OnPropertyChanged("CodeMinWallThickness");
            }
        }

        public double DesignTemperature
        {
            get => _designTemperature;
            set
            {
                _designTemperature = value;
                OnPropertyChanged("DesignTemperature");
            }
        }

        public double DesignPressure
        {
            get => _designPressure;
            set
            {
                _designPressure = value;
                OnPropertyChanged("DesignPressure");
            }
        }

        public double OperatingPressure
        {
            get => _operatingPressure;
            set
            {
                _operatingPressure = value;
                OnPropertyChanged("OperatingPressure");
            }
        }

        public double OperatingTemperature
        {
            get => _operatingTemperature;
            set
            {
                _operatingTemperature = value;
                OnPropertyChanged("OperatingTemperature");
            }
        }

        public string WaterStream
        {
            get => _waterStream;
            set
            {
                _waterStream = value;
                OnPropertyChanged("WaterStream");
            }
        }

        [Indexed]
        public int UnitId { get; set; }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
