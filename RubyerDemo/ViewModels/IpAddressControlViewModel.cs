using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyerDemo.ViewModels
{
    /// <summary>
    /// 文本框
    /// </summary>
    public partial class IpAddressControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private string ipAddress;

        [RelayCommand]
        private void SetIp()
        {
            IpAddress = "192.168.1.1";
        }
    }
}
