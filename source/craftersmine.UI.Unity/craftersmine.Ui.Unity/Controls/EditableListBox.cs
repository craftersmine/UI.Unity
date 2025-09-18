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
    public class EditableListBox : ListBox
    {
        internal static readonly DependencyProperty HeaderVisibilityProperty = DependencyProperty.Register(nameof(HeaderVisibility), typeof(Visibility), typeof(EditableListBox), new PropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(object), typeof(EditableListBox), new PropertyMetadata(null, OnHeaderPropertyChanged));
        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(EditableListBox), new PropertyMetadata(null, OnHeaderPropertyChanged));
        public static readonly DependencyProperty HeaderTemplateSelectorProperty = DependencyProperty.Register(nameof(HeaderTemplateSelector), typeof(DataTemplateSelector), typeof(EditableListBox), new PropertyMetadata(null, OnHeaderPropertyChanged));

        private static readonly DependencyPropertyKey HasHeaderPropertyKey = DependencyProperty.RegisterReadOnly(nameof(HasHeader), typeof(bool), typeof(EditableListBox), new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty HasHeaderProperty = HasHeaderPropertyKey.DependencyProperty;

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

        public event RoutedEventHandler? AddClick;
        public event RoutedEventHandler? RemoveClick;

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
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("AddButton") is Button addButton)
                addButton.Click += (s, e) => AddClick?.Invoke(this, e);
            if (GetTemplateChild("RemoveButton") is Button removeButton)
                removeButton.Click += (s, e) => RemoveClick?.Invoke(this, e);
        }

        private static void OnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EditableListBox? lb = d as EditableListBox;
            if (lb is null)
                return;
            lb.UpdateHasHeaderProperty();
        }

        private void UpdateHasHeaderProperty()
        {
            bool hasHeader = Header is not null || HeaderTemplate is not null || HeaderTemplateSelector is not null;
            SetValue(HasHeaderPropertyKey, hasHeader);
        }
    }
}
