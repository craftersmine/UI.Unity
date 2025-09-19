using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace craftersmine.Ui.Unity.Controls
{
    public class UnityColorPicker : Button
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof(Color), typeof(Color), typeof(UnityColorPicker), new PropertyMetadata(Colors.Black, OnColorPropertyChanged));

        static UnityColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnityColorPicker), new FrameworkPropertyMetadata(typeof(UnityColorPicker)));
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        private static void OnColorPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UnityColorPicker? picker = o as UnityColorPicker;
            if (picker is null)
                return;

            Rectangle? selColorRect = picker.GetTemplateChild("SelectedColorRectangle") as Rectangle;
            if (selColorRect is null)
                return;

            Border? alphaIndicatorBorder = picker.GetTemplateChild("AlphaIndicator") as Border;
            Border? alphaIndicatorTrackBorder = picker.GetTemplateChild("AlphaIndicatorTrack") as Border;

            if (alphaIndicatorTrackBorder is null || alphaIndicatorBorder is null)
                return;

            o.SetValue(e.Property, e.NewValue);
            Color fillColor = picker.Color;
            fillColor.A = 255;
            selColorRect.Fill = new SolidColorBrush(fillColor);

            alphaIndicatorBorder.Width = (alphaIndicatorTrackBorder.ActualWidth / 255) * picker.Color.A;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
