using System;
using System.Windows;

namespace Rubyer
{
    /// <summary>
    /// 资源管理器
    /// </summary>
    public static class ResourceManager
    {
        internal static ResourceDictionary Resources { get; } = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/Rubyer;component/Themes/Generic.xaml", UriKind.Absolute)
        };

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源</returns>
        public static T TryGetResource<T>(string resourceName) where T : class
        {
            if (Resources.Contains(resourceName))
            {
                return Resources[resourceName] as T;
            }

            return null;
        }

        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源</returns>
        public static object TryGetResource(string resourceName)
        {
            if (Resources.Contains(resourceName))
            {
                return Resources[resourceName];
            }

            return null;
        }
    }
}
