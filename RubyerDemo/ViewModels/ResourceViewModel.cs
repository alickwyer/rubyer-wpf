using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rubyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RubyerDemo.ViewModels
{
    /// <summary>
    /// 资源
    /// </summary>
    public partial class ResourceViewModel : ObservableObject
    {
        public List<ColorInfo> LightColorInfos { get; } = [];
        public List<ColorInfo> DarkColorInfos { get; } = [];

        public ResourceViewModel()
        {
            var application = Application.Current;
            foreach (var colorKey in ThemeManager.ColorKeys)
            {
                string lightColorKey = ThemeManager.GetLightColor(application, colorKey.Key);
                string darkColorKey = ThemeManager.GetDarkColor(application, colorKey.Key);
                Color lightColor = (Color)application.FindResource(lightColorKey);
                Color darkColor = (Color)application.FindResource(darkColorKey);
                LightColorInfos.Add(new ColorInfo(lightColor, lightColorKey, colorKey.Value));
                DarkColorInfos.Add(new ColorInfo(darkColor, darkColorKey, colorKey.Value));
            }
        }

        [RelayCommand]
        private void CopyColor(ColorInfo colorInfo)
        {
            ClearColorsCoyied();
            var text = $"<Color x:Key=\"{colorInfo.Key}\">{colorInfo.Color}</Color>";
            Clipboard.SetText(text);
            colorInfo.IsCopied = true;
        }

        private void ClearColorsCoyied()
        {
            LightColorInfos.ForEach(x => x.IsCopied = false);
            DarkColorInfos.ForEach(x => x.IsCopied = false);
        }
    }

    public partial class ColorInfo : ObservableObject
    {
        public Color Color { get; set; }
        public string Key { get; set; }
        public string Hex { get; set; }
        public string Description { get; set; }
        [ObservableProperty] private bool isCopied;

        public ColorInfo(Color color, string key, string description)
        {
            Color = color;
            Key = key;
            Description = description;
        }
    }
}
