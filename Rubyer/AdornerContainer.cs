using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Rubyer
{
    /// <summary>
    /// 装饰器容器
    /// </summary>
    [DefaultProperty("Element")]
    [ContentProperty("Element")]
    public class AdornerContainer : Control
    {
        private AdornerLayer _adornerLayer;
        private BadgeAdorner _adorner;

        /// <summary>
        /// 显示的元素
        /// </summary>
        public static readonly DependencyProperty ElementProperty =
            DependencyProperty.Register("Element", typeof(FrameworkElement), typeof(AdornerContainer), new PropertyMetadata(null, OnElementChanged));

        /// <summary>
        /// 元素偏移
        /// </summary>
        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof(Point), typeof(AdornerContainer), new PropertyMetadata(new Point(), OnElementChanged));

        /// <summary>
        /// 显示的元素
        /// </summary>
        public FrameworkElement Element
        {
            get { return (FrameworkElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        /// <summary>
        /// 元素偏移
        /// </summary>
        public Point Offset
        {
            get { return (Point)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        /// <inheritdoc/> 
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        private static void OnElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AdornerContainer adornerContainer)
            {
                adornerContainer.UpdateAdorner();
            }                
        }

        private void UpdateAdorner()
        {
            RemoveAdorner();

            if (Parent is UIElement parentElement)
            {
                _adornerLayer = AdornerLayer.GetAdornerLayer(parentElement);
                if (_adornerLayer != null)
                {
                    _adorner = new BadgeAdorner(parentElement, Element, Offset);
                    _adornerLayer.Add(_adorner);
                }
            }
        }

        private void RemoveAdorner()
        {
            if (_adornerLayer != null && _adorner != null)
            {
                _adornerLayer.Remove(_adorner);
                _adorner = null;
            }
        }
    }
}
