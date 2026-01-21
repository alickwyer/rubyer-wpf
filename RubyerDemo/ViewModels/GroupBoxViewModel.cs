using CommunityToolkit.Mvvm.ComponentModel;
using Rubyer;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace RubyerDemo.ViewModels
{
    /// <summary>
    /// 分组框
    /// </summary>
    public partial class GroupBoxViewModel : ObservableObject
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
        private Brush foreground;

        [ObservableProperty]
        private Brush background;

        [ObservableProperty]
        private FontWeight fontWeight;

        [ObservableProperty]
        private FontFamily fontFamily;

        public GroupBoxViewModel()
        {
            Foreground = AllBrushes[0];
            Background = AllBrushes[2];
            FontWeight = FontWeights.Normal;
            fontFamily = AllFontFamilys.FirstOrDefault(x=>x.Source.Contains("YaHei"));
        }
    }
}
