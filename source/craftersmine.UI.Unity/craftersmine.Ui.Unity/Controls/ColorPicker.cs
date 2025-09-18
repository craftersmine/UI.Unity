using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace craftersmine.Ui.Unity.Controls
{
    public class UnityColorPicker : Control
    {
        static UnityColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnityColorPicker), new FrameworkPropertyMetadata(typeof(UnityColorPicker)));
        }
    }
}
