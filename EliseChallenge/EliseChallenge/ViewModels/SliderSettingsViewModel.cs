using Caliburn.Micro;
using Plugin.Segmented.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliseChallenge
{
    public class SliderSettingsViewModel : Screen
    {
        public SliderSettingsViewModel()
        {
            SegmentItemsSource = new List<SegmentedControlOption>(){
                 new SegmentedControlOption{Text="Test0"},
                new SegmentedControlOption{Text="Test1"},
                new SegmentedControlOption{Text="Test2"}
            };

        }
        public bool IsDoubleSetting { get; set; }

        public string SelectedSegment { get; set; }
        private IList<SegmentedControlOption> _segmentItemsSource;
        public IList<SegmentedControlOption> SegmentItemsSource
        {
            get => _segmentItemsSource;
            set { _segmentItemsSource = value; OnPropertyChanged(new PropertyChangedEventArgs(nameof(SegmentItemsSource))); }
        }
        public int RoundingDigits { get; set; }

        public float Minimum { get; set; }

        public float Value { get; set; }

        public float Maximum { get; set; }
    }
}
