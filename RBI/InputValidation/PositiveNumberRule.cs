using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RBI.InputValidation
{
    class PositiveNumberRule : ValidationRule
    {
        private const double Min = 0;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double num = 0;

            try
            {
                if (((string)value).Length > 0)
                {
                    num = Double.Parse((String)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if ((num < Min))
            {
                return new ValidationResult(false, "Number must be greater or equal to 0");
            }

            return ValidationResult.ValidResult;
        }
    }
}
