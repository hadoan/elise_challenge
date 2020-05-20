using Caliburn.Micro;

namespace EliseChallenge
{
    public class SliderSettingsViewModel : Screen
    {
        public SliderSettingsViewModel()
        {
          

        }
        public bool IsDoubleSetting { get; set; }

       
        public int RoundingDigits { get; set; }

        public float Minimum { get; set; }

        public float Value { get; set; }

        public float Maximum { get; set; }


        public void Save()
        {
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }

    }
}
