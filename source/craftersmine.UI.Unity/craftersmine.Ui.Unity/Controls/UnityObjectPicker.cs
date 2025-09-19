using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace craftersmine.Ui.Unity.Controls
{
    public class UnityObjectPicker : Button
    {
        public static readonly DependencyProperty SelectedObjectProperty = DependencyProperty.Register(
            nameof(SelectedObject),
            typeof(object),
            typeof(UnityObjectPicker),
            new PropertyMetadata(null, OnSelectedObjectPropertyChanged));
        public static readonly DependencyProperty AllowedTypeProperty = DependencyProperty.Register(
            nameof(AllowedType),
            typeof(Type),
            typeof(UnityObjectPicker),
            new PropertyMetadata(typeof(object), OnAllowedTypePropertyChanged));
        public static readonly DependencyProperty AllowInheritedProperty = DependencyProperty.Register(
            nameof(AllowInherited),
            typeof(bool),
            typeof(UnityObjectPicker),
            new PropertyMetadata(true, OnAllowInheritedPropertyChanged));
        public static readonly DependencyProperty NullPlaceholderProperty = DependencyProperty.Register(
            nameof(NullPlaceholder),
            typeof(object),
            typeof(UnityObjectPicker),
            new PropertyMetadata("None (Object)"));
        public static readonly DependencyPropertyKey ObjectIconPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(ObjectIcon),
            typeof(ImageSource),
            typeof(UnityObjectPicker),
            new PropertyMetadata(null));
        public static readonly DependencyProperty ObjectIconProperty = ObjectIconPropertyKey.DependencyProperty;
        internal static readonly DependencyPropertyKey ObjectNamePropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(ObjectName),
            typeof(string),
            typeof(UnityObjectPicker),
            new PropertyMetadata(null));
        internal static readonly DependencyProperty ObjectNameProperty = ObjectNamePropertyKey.DependencyProperty;

        static UnityObjectPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnityObjectPicker), new FrameworkPropertyMetadata(typeof(UnityObjectPicker)));
        }

        public object? SelectedObject
        {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }
        public Type AllowedType
        {
            get => (Type)GetValue(AllowedTypeProperty);
            set => SetValue(AllowedTypeProperty, value);
        }
        public bool AllowInherited
        {
            get => (bool)GetValue(AllowInheritedProperty);
            set => SetValue(AllowInheritedProperty, value);
        }
        public object NullPlaceholder
        {
            get => GetValue(NullPlaceholderProperty);
            set => SetValue(NullPlaceholderProperty, value);
        }
        public ImageSource? ObjectIcon
        {
            get => (ImageSource)GetValue(ObjectIconProperty);
        }
        internal string ObjectName
        {
            get => (string)GetValue(ObjectNameProperty);
        }

        private static void OnSelectedObjectPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UnityObjectPicker? picker = d as UnityObjectPicker;
            if (picker is null)
                return;

            if (!CheckTypeAllowance(e.NewValue.GetType(), picker.AllowedType, picker.AllowInherited))
                return;

            picker.SetValue(SelectedObjectProperty, e.NewValue);
            picker.SetValue(ObjectIconPropertyKey, GetIconImageSource(e.NewValue.GetType()));
            picker.SetValue(ObjectNamePropertyKey, GetObjectName(e.NewValue));
        }

        private static void OnAllowInheritedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UnityObjectPicker? picker = d as UnityObjectPicker;
            if (picker is null) 
                return;

            if (picker.SelectedObject is null)
                return;

            if (!CheckTypeAllowance(picker.SelectedObject.GetType(), picker.AllowedType, picker.AllowInherited))
                picker.SelectedObject = null;
        }

        private static void OnAllowedTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UnityObjectPicker? picker = d as UnityObjectPicker;
            if (picker is null)
                return;

            if (picker.SelectedObject is null)
                return;

            if (!CheckTypeAllowance(picker.SelectedObject.GetType(), picker.AllowedType, picker.AllowInherited))
                picker.SelectedObject = null;

            picker.NullPlaceholder = string.Format("None ({0})", picker.AllowedType.Name);
        }

        private static bool CheckTypeAllowance(Type t1, Type t2, bool allowInheritance)
        {
            if (t1 == t2)
                return true;

            if (t1.IsAssignableTo(t2) && allowInheritance)
                return true;

            return false;
        }

        private static ImageSource? GetIconImageSource(Type objectType)
        {
            return null;
        }

        private static string GetObjectName(object obj)
        {
            return string.Format("{0} ({1})", obj.ToString(), obj.GetType().Name);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            NullPlaceholder = string.Format("None ({0})", AllowedType.Name);
        }
    }
}
