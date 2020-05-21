using Caliburn.Micro;
using System.Windows;

namespace EliseChallenge
{
    public class SliderSettingsViewModel : Screen
    {
        private bool isInt;
        private bool isDouble;
        private int roundingDigits;

        public SliderSettingsViewModel()
        {
            IsInt = true;
            RoundingDigits = 2;
        }
        public bool IsDouble
        {
            get => isDouble;
            set
            {
                isDouble = value;
                isInt = !value;
                NotifySettingVisibility();
            }
        }

        public bool IsInt
        {
            get => isInt;
            set
            {
                isInt = value;
                isDouble = !value;
                if (value) RoundingDigits = 2;
                NotifySettingVisibility();
            }
        }

        public Visibility IsDoubleSettingVisibility => IsDouble ? Visibility.Visible : Visibility.Collapsed;

        public Visibility IsIntSettingVisibility => IsInt ? Visibility.Visible : Visibility.Collapsed;

        public int RoundingDigits
        {
            get => roundingDigits; set
            {
                roundingDigits = value;
                NotifyOfPropertyChange(() => RoundingDigits);
            }
        }

        public double Minimum { get; set; }

        public string MinimumText { get; set; }

        public double Value { get; set; }

        public double Maximum { get; set; }

        private bool CanSave()
        {
            return 0 <= Minimum && Minimum <= Value && Value <= Maximum && Maximum > 0;
        }

        public void Save()
        {
            var view = this.GetView() as SliderSettingsView;
            var errors = view.GetValidationErrors(this.IsInt);
            if (!string.IsNullOrWhiteSpace(errors))
                MessageBox.Show(errors, "Error!");
            else if (!CanSave())
                MessageBox.Show("Value validation error, please correct and try again!");
            else
                TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }


        private void NotifySettingVisibility()
        {
            NotifyOfPropertyChange(() => IsDouble);
            NotifyOfPropertyChange(() => IsInt);
            NotifyOfPropertyChange(() => IsDoubleSettingVisibility);
            NotifyOfPropertyChange(() => IsIntSettingVisibility);
            NotifyOfPropertyChange(() => RoundingDigits);
        }
    }
}
