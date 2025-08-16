using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace craftersmine.Ui.Unity.Controls
{
    public class HelpBox : ContentControl
    {
        public static readonly DependencyProperty HelpBoxTypeProperty = DependencyProperty.Register(nameof(Type), typeof(HelpBoxType), typeof(HelpBox), new PropertyMetadata(HelpBoxType.Info));

        public HelpBoxType Type
        {
            get => (HelpBoxType)GetValue(HelpBoxTypeProperty);
            set => SetValue(HelpBoxTypeProperty, value);
        }

        static HelpBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HelpBox), new FrameworkPropertyMetadata(typeof(HelpBox)));
        }
    }

    public enum HelpBoxType
    {
        Info,
        Warning,
        Error
    }
}
