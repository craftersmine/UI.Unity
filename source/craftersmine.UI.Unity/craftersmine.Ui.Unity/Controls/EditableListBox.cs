using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace craftersmine.Ui.Unity.Controls
{
    public class EditableListBox : Selector
    {
        internal static readonly DependencyProperty HeaderVisibilityProperty = DependencyProperty.Register(nameof(HeaderVisibility), typeof(Visibility), typeof(EditableListBox), new PropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(object), typeof(EditableListBox), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(EditableListBox), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderTemplateSelectorProperty = DependencyProperty.Register(nameof(HeaderTemplateSelector), typeof(DataTemplateSelector), typeof(EditableListBox), new PropertyMetadata(null));

        public static readonly DependencyProperty HasHeaderProperty = DependencyProperty.Register(nameof(HasHeader), typeof(bool), typeof(EditableListBox), new PropertyMetadata(false));

        static EditableListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableListBox), new FrameworkPropertyMetadata(typeof(EditableListBox)));
        }

        internal Visibility HeaderVisibility
        {
            get
            {
                if (Items.Count > 0)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public object Header
        {
            get => (object)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public DataTemplate HeaderTemplate
        {
            get => (DataTemplate)GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }
        public DataTemplateSelector HeaderTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty);
            set => SetValue(HeaderTemplateSelectorProperty, value);
        }

        public bool HasHeader
        {
            get => (bool)GetValue(HasHeaderProperty);
            set => SetValue(HasHeaderProperty, Header is not null || HeaderTemplate is not null);
        }

        public void OnAddClick(object sender, RoutedEventArgs e)
        {
            Debugger.Break();
        }
        public void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            Debugger.Break();
        }
    }
}
