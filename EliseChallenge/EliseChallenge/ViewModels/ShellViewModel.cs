using Caliburn.Micro;
using System.Windows;

namespace EliseChallenge {
    public class ShellViewModel : Conductor<object>, IShell {
        
        public void ShowSettings()
        {
            IWindowManager manager = new WindowManager();
            var vm = new SliderSettingsViewModel()
            {
                Minimum = this.Minimum,
                Maximum = this.Maximum,
                Value = this.Value
            };

            var result = manager.ShowDialog(vm, null, null);
            if(result.HasValue && result.Value)
            {
                //set data for slider
                this.Minimum = vm.Minimum;
                this.Maximum = vm.Maximum;
                this.Value = vm.Value;
                NotifyOfPropertyChange(() => Minimum);
                NotifyOfPropertyChange(() => Maximum);
                NotifyOfPropertyChange(() => Value);
            }

        }

        public float Minimum { get; set; }
        public float Maximum { get; set; }
        public float Value { get; set; }
    }
}