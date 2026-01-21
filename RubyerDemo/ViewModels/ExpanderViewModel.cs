using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using Rubyer;

namespace RubyerDemo.ViewModels
{
    /// <summary>
    /// 扩展框
    /// </summary>
    public partial class ExpanderViewModel : ObservableObject
    {
        public List<Brush> AllBrushes => new List<Brush>
        {
            ResourceManager.TryGetResource<Brush>("DefaultForeground"),
            ResourceManager.TryGetResource<Brush>("DefaultBackground"),
            ResourceManager.TryGetResource<Brush>("Primary"),
            ResourceManager.TryGetResource<Brush>("Light"),
            ResourceManager.TryGetResource<Brush>("Dark"),
            ResourceManager.TryGetResource<Brush>("Accent"),
            ResourceManager.TryGetResource<Brush>("Success"),
            ResourceManager.TryGetResource<Brush>("Warning"),
            ResourceManager.TryGetResource<Brush>("Info"),
            ResourceManager.TryGetResource<Brush>("Error"),
        };

        public List<FontWeight> AllFontWeights => new List<FontWeight>
        {
           FontWeights.Black ,
           FontWeights.Bold ,
           FontWeights.DemiBold ,
           FontWeights.ExtraBlack ,
           FontWeights.ExtraBold ,
           FontWeights.ExtraLight ,
           FontWeights.Heavy ,
           FontWeights.Light ,
           FontWeights.Medium ,
           FontWeights.Regular ,
           FontWeights.SemiBold ,
           FontWeights.Thin ,
           FontWeights.UltraBlack ,
           FontWeights.UltraBold ,
           FontWeights.UltraLight ,
        };

        public List<FontFamily> AllFontFamilys => Fonts.SystemFontFamilies.ToList();

        [ObservableProperty]
        private HorizontalAlignment horizontalAlignment;

        [ObservableProperty]
        private VerticalAlignment verticalAlignment;

        [ObservableProperty]
        private Brush foreground;

        [ObservableProperty]
        private Brush background;

        [ObservableProperty]
        private Brush contentForeground;

        [ObservableProperty]
        private Brush contentBackground;

        [ObservableProperty]
        private FontWeight fontWeight;

        [ObservableProperty]
        private FontFamily fontFamily;

        public ExpanderViewModel()
        {
            Foreground = AllBrushes[1];
            ContentForeground = AllBrushes[0];
            Background = AllBrushes[2];
            ContentBackground = AllBrushes[1];
            FontWeight = FontWeights.Normal;
            fontFamily = AllFontFamilys.FirstOrDefault(x => x.Source.Contains("YaHei"));
        }
    }
}
