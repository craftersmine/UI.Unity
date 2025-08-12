using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace craftersmine.Ui.Unity.Styles
{
    partial class Window : ResourceDictionary
    {
        public void OnIconMouseUp(object sender, MouseEventArgs e)
        {
            sender.ForWindowFromTemplate()
            if (e.LeftButton == MouseButtonState.Released)
            {
                SystemCommands.ShowSystemMenu();
            }
        }
    }
}
