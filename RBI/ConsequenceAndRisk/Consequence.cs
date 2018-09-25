using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RBI.Annotations;

namespace RBI.ConsequenceAndRisk
{
    public class Consequence : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const int MinorRisk = 1;
        private const int LowRisk = 2;
        private const int MediumRisk = 3;
        private const int MajorRisk = 4;
        private const int SevereRisk = 5;
        private const int CatastrophicRisk = 6;

        private double _estimatedCostToBusiness;  // Thousand $
        private int _healthSafetyRisk;  // 1 - 6
        private int _businessInteruptionRisk;  // 1 - 6 
        private int _financialCost;  // 1 - 6
        private int _environmentalRisk;  // 1 - 6
        private int _reputationDamage; // 1 - 6
        private string _levelOfDamage;
        private string _locationOfDamage;
        private string _probableAction;
        private string _possibleDamage;
        private double _estimatedCapitalRepairCost;
        private int _estimatedRepairReplaceDuration;
        private double _generationRevenue;
        private double _sizeOfGenerator;

        #region Consequence properties setter and getter

        public string LevelOfDamage
        {
            get => _levelOfDamage;
            set
            {
                _levelOfDamage = value;
                OnPropertyChanged("LevelOfDamage");
            }

        }

        public string LocationOfDamage
        {
            get => _locationOfDamage;
            set
            {
                _locationOfDamage = value;
                OnPropertyChanged("LocationOfDamage");
            }
        }

        public string ProbableAction
        {
            get => _probableAction;
            set
            {
                _probableAction = value;
                OnPropertyChanged("ProbableAction");
            }
        }

        public string PossibleDamage
        {
            get => _possibleDamage;
            set
            {
                _possibleDamage = value;
                OnPropertyChanged("PossibleDamage");
            }
        }

        public double EstimatedCapitalRepairCost
        {
            get => _estimatedCapitalRepairCost;
            set
            {
                _estimatedCapitalRepairCost = value;
                OnPropertyChanged("EstimatedCapitalRepairCost");
            }
        }

        public int EstimatedRepairReplaceDuration
        {
            get => _estimatedRepairReplaceDuration;
            set
            {
                _estimatedRepairReplaceDuration = value;
                OnPropertyChanged("EstimatedRepairReplaceDuration");
            }
        }

        public double GenerationRevenue  // $ per MWh
        {
            get => _generationRevenue;
            set
            {
                _generationRevenue = value;
                OnPropertyChanged("GenerationRevenue");
            }
        }

        public double SizeOfGenerator  // MW
        {
            get => _sizeOfGenerator;
            set
            {
                _sizeOfGenerator = value;
                OnPropertyChanged("SizeOfGenerator");
            }
        }  
        public double EstimatedCostToBusiness
        {
            get => _estimatedCostToBusiness;
            private set => _estimatedCostToBusiness = _estimatedCapitalRepairCost
                                                      + _generationRevenue * _sizeOfGenerator
                                                      * _estimatedRepairReplaceDuration
                                                      * 24 * 0.001;
        }

        public int HealthSafetyRisk
        {
            get => _healthSafetyRisk;
            set
            {
                _healthSafetyRisk = value;
                OnPropertyChanged("HealthSafetyRisk");
            }
        }

        public int EnvironmentalRisk
        {
            get => _environmentalRisk;
            set
            {
                _environmentalRisk = value;
                OnPropertyChanged("EnvironmentalRisk");
            }
        }

        public int ReputationalDamage
        {
            get => _reputationDamage;
            set
            {
                _reputationDamage = value;
                OnPropertyChanged("ReputationalDamage");
            }
        }

        public int BusinessInteruptionRisk
        {
            get => _businessInteruptionRisk;
            private set
            {
                if (0 <= _estimatedRepairReplaceDuration && _estimatedRepairReplaceDuration <= 0.5)
                    _businessInteruptionRisk = MinorRisk;  //Minor risk
                else if (0.5 < _estimatedRepairReplaceDuration && _estimatedRepairReplaceDuration <= 2)
                    _businessInteruptionRisk = LowRisk;  //Low risk
                else if (2 < _estimatedRepairReplaceDuration && _estimatedRepairReplaceDuration <= 20)
                    _businessInteruptionRisk = MediumRisk;  //Medium risk
                else if (20 < _estimatedRepairReplaceDuration && _estimatedRepairReplaceDuration <= 100)
                    _businessInteruptionRisk = MajorRisk;  //Major risk
                else if (100 < _estimatedRepairReplaceDuration && _estimatedRepairReplaceDuration <= 200)
                    _businessInteruptionRisk = SevereRisk;  //Severe risk
                else if (200 < _estimatedRepairReplaceDuration)
                    _businessInteruptionRisk = CatastrophicRisk;  //Catastrophic risk
            }
        }

        public int FinancialCost
        {
            get => _financialCost;
            private set
            {
                if (0 <= _estimatedCostToBusiness && _estimatedCostToBusiness < 250)
                    _financialCost = MinorRisk;
                else if (250 <= _estimatedCostToBusiness && _estimatedCostToBusiness <= 1000)
                    _financialCost = LowRisk;
                else if (1000 < _estimatedCostToBusiness && _estimatedCostToBusiness <= 10000)
                    _financialCost = MediumRisk;
                else if (10000 < _estimatedCostToBusiness && _estimatedCostToBusiness <= 50000)
                    _financialCost = MajorRisk;
                else if (50000 < _estimatedCostToBusiness && _estimatedCostToBusiness <= 100000)
                    _financialCost = SevereRisk;
                else if (100000 < _estimatedCostToBusiness)
                    _financialCost = CatastrophicRisk;
            }
        }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
