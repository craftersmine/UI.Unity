using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace craftersmine.Ui.Unity.Styles
{
    partial class Window : ResourceDictionary
    {
        public void OnIconMouseUp(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                sender.ForWindowFromTemplate(w => SystemCommands.ShowSystemMenu(w, ((Image)sender).PointToScreen(new Point(0, 0))));
            }
        }

        public void OnCloseClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => SystemCommands.CloseWindow(w));
        }

        public void OnMinimizeClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => SystemCommands.MinimizeWindow(w));
        }

        public void OnMaximizeClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w =>
            {
                switch (w.WindowState)
                {
                    case WindowState.Maximized:
                        SystemCommands.RestoreWindow(w);
                        break;
                    case WindowState.Normal:
                        SystemCommands.MaximizeWindow(w);
                        break;
                    default:
                        return;
                }
            });
        }
    }
}
