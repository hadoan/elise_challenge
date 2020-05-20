using Caliburn.Micro;

namespace EliseChallenge {
    public class ShellViewModel : Conductor<object>, IShell {
        
        public void ShowSettings()
        {
            IWindowManager manager = new WindowManager();
            manager.ShowDialog(new SliderSettingsViewModel(), null, null);
        }
    }
}