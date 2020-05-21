using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EliseChallenge
{
    public partial class SliderSettingsView : Window
    {
        public SliderSettingsView()
        {
            InitializeComponent();
        }

        public string GetValidationErrors(bool isInt)
        {
            var roundingErrors = Validation.GetErrors(this.RoundingDigits);
            var minErrors = isInt ? Validation.GetErrors(this.MinimumInt) : Validation.GetErrors(this.MinimumDouble);
            var valueErrors = isInt ? Validation.GetErrors(this.ValueInt) : Validation.GetErrors(this.ValueDouble);
            var maxErrors = isInt ? Validation.GetErrors(this.MaximumInt) : Validation.GetErrors(this.MaximumDouble);

            var errors = isInt ? new List<object>() : roundingErrors.Select(x => x.ErrorContent).ToList();
            errors.AddRange(minErrors.Select(x => x.ErrorContent));
            errors.AddRange(valueErrors.Select(x => x.ErrorContent));
            errors.AddRange(maxErrors.Select(x => x.ErrorContent));

            return string.Join("\r\n", errors);
        }

    }
}
