using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace craftersmine.Ui.Unity
{
    public class DepthToMarginConverter : IValueConverter
    {
        public double IndentSize { get; set; } = 16;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TreeViewItem tvi)
            {
                int depth = 0;
                ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(tvi);
                while (parent is TreeViewItem p)
                {
                    depth++;
                    parent = ItemsControl.ItemsControlFromItemContainer(p);
                }
                return new Thickness(depth * IndentSize, 0, 0, 0);
            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Binding.DoNothing;
    }
}
