using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace craftersmine.Ui.Unity
{
    internal class ColorBlendExtension : MarkupExtension
    {
        private readonly object? baseColor;
        private readonly object? addedColor;
        private readonly double factor;

        public ColorBlendExtension(object? baseColor, object? addedColor, double factor = 0.5)
        {
            this.baseColor = baseColor;
            this.addedColor = addedColor;
            this.factor = factor;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var color1 = Resolve(addedColor, target);
            var color2 = Resolve(baseColor, target);

            return UnityUiHelpers.Blend(color1, color2, factor);
        }

        private static Color Resolve(object value, IProvideValueTarget target)
        {
            if (value is Color c)
                return c;
            if (value is SolidColorBrush brush)
                return brush.Color;
            if (value is Expression expression)
                return FindResource<Color>(ResolveResourceKey(expression), target);

            return Colors.Transparent;
        }

        private static object ResolveResourceKey(object expression)
        {
            object? val = expression.GetType().GetProperty("ResourceKey")?.GetValue(expression);
            if (val is null)
                throw new ArgumentException(nameof(expression));

            return val;
        }

        private static T? FindResource<T>(object key, IProvideValueTarget target)
        {
            Type? type;
            T? value = default;
            try
            {
                type = target.TargetObject.GetType();
                if (target.TargetObject is FrameworkElement fe && fe.Parent != null)
                    value = (T)fe.FindResource(key);
                if (target.TargetObject is FrameworkContentElement fce && fce.Parent != null)
                    value = (T)fce.FindResource(key);

                value = (T)Application.Current.FindResource(key);
            }
            catch { }
            return value;
        }
    }
}
