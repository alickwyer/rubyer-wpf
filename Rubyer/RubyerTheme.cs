using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Rubyer
{
    public class RubyerTheme : ResourceDictionary
    {
        private Enums.ThemeMode themeMode = Enums.ThemeMode.System;
        public Enums.ThemeMode ThemeMode
        {
            get => themeMode;
            set
            {
                if (SetField(ref themeMode, value))
                {
                    ThemeManager.SwitchThemeMode(themeMode);
                }
            }
        }

        private double controlCornerRadius = 3;
        public double ControlCornerRadius
        {
            get => controlCornerRadius;
            set
            {
                if (SetField(ref controlCornerRadius, value))
                {
                    ThemeManager.SwitchControlCornerRadius(controlCornerRadius);
                }
            }
        }

        private double containerCornerRadius = 5;
        public double ContainerCornerRadius
        {
            get => containerCornerRadius;
            set
            {
                if (SetField(ref containerCornerRadius, value))
                {
                    ThemeManager.SwitchContainerCornerRadius(containerCornerRadius);
                }
            }
        }

        private double defaultFontSize = 14;
        public double DefaultFontSize
        {
            get => defaultFontSize;
            set
            {
                if (SetField(ref defaultFontSize, value))
                {
                    ThemeManager.SwitchDefaultFontSize(defaultFontSize);
                }
            }
        }

        public IEnumerable<string> CultureNames = ["zh-CN", "en-US"];

        private string cultureName = "zh-CN";
        public string CultureName
        {
            get => cultureName;
            set
            {
                if (CultureNames.Contains(value) && SetField(ref cultureName, value))
                {
                    ThemeManager.SwitchCulture(cultureName);
                }
            }
        }

        public RubyerTheme()
        {
            Source = new Uri(@"pack://application:,,,/Rubyer;component/Themes/Generic.xaml");
        }

        protected static bool SetField<T>(ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            return true;
        }
    }
}
