using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Rubyer
{
    /// <summary>
    /// 元素装饰器
    /// （传入的元素在 AdornerLayer 显示）
    /// </summary>
    public class ElementAdorner : Adorner
    {
        private readonly UIElement adorner;

        /// <summary>
        /// 偏移
        /// </summary>
        public Point Offset { get; }

        /// <summary>
        /// 标记
        /// </summary>
        /// <param name="adornedElement">被装饰元素</param>
        /// <param name="adorner">装饰</param>
        /// <param name="offset">偏移</param>
        public ElementAdorner(UIElement adornedElement, FrameworkElement adorner, Point offset)
            : base(adornedElement)
        {
            this.adorner = adorner;

            if (adornedElement is FrameworkElement fe)
            {
                DataContext = fe.DataContext;
                fe.DataContextChanged += (_, e) => DataContext = e.NewValue;
            }

            Offset = offset;

            var parent = VisualTreeHelper.GetParent(adorner);
            if (parent is ElementAdorner badgeAdorner)
            {
                badgeAdorner.RemoveVisualChild(adorner);
            }

            AddVisualChild(adorner);
        }

        /// <inheritdoc/> 
        protected override int VisualChildrenCount => 1;

        /// <inheritdoc/> 
        protected override Visual GetVisualChild(int index) => adorner;

        /// <inheritdoc/> 
        protected override Size MeasureOverride(Size constraint)
        {
            adorner.Measure(constraint);
            return adorner.DesiredSize;
        }

        /// <inheritdoc/> 
        protected override Size ArrangeOverride(Size finalSize)
        {
            var x = Offset.X;
            var y = Offset.Y;
            var rect = new Rect(new Point(x, y), adorner.DesiredSize);
            adorner.Arrange(rect);

            return finalSize;
        }
    }
}
