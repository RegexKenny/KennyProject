using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RBI.InputValidation
{
    class RiskLevelRule : ValidationRule
    {
        private readonly int[] _riskLevel = {1,2,3,4,5,6};

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int risk = 0;

            try
            {
                if (((string)value).Length > 0)
                {
                    risk = Int32.Parse((String)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if (!_riskLevel.Contains(risk))
            {
                return new ValidationResult(false, "Risk level must be from 1 to 6");
            }

            return ValidationResult.ValidResult;
        }
    }
}
