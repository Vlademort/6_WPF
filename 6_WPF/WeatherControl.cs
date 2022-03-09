using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _6_WPF
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string direction_wind;
        private int speed_wind;
        private int precipitation;

        public string DirectionWind
        {
            get => direction_wind;
            set => direction_wind = value;
        }
        public int SpeedWind
        {
            get => speed_wind;
            set => speed_wind = value;
        }
        public enum Precipitation
        {
            солнечно = 0,
            облачно = 1,
            дождь = 2,
            снег = 4
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }       
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceAge)),
                new ValidateValueCallback(ValidateAge));
        }

        private static bool ValidateAge(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceAge(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        public string Print()
        {
            return $"{DirectionWind} {Temperature}";
        }
    
    }
}
