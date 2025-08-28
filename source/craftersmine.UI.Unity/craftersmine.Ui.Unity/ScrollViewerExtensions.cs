using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace craftersmine.Ui.Unity
{
    internal static class ScrollViewerExtensions
    {
        public static readonly DependencyProperty HorizontalScrollOnWheelProperty = DependencyProperty.RegisterAttached(
            "HorizontalScrollOnWheel",
            typeof(bool),
            typeof(ScrollViewerExtensions),
            new UIPropertyMetadata(false, OnHorizontalScrollOnWheelChanged));

        public static bool GetHorizontalScrollOnWheel(DependencyObject obj)
        {
            return (bool)obj.GetValue(HorizontalScrollOnWheelProperty);
        }
        
        public static void SetHorizontalScrollOnWheel(DependencyObject obj, bool value)
        {
            obj.SetValue(HorizontalScrollOnWheelProperty, value);
        }

        private static void OnHorizontalScrollOnWheelChanged(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
        {
            if (dObj is UIElement element)
            {
                if ((bool)e.NewValue)
                    element.PreviewMouseWheel += OnPreviewMouseWheel;
                else
                    element.PreviewMouseWheel -= OnPreviewMouseWheel;
            }
        }

        private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is ScrollViewer sv)
            {
                if (e.Delta > 0)
                    sv.LineLeft();
                else
                    sv.LineRight();

                e.Handled = true;
            }
        }
    }
}
