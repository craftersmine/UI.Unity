using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace craftersmine.Ui.Unity.Controls
{
    public class EditableListBox : ListBox
    {
        static EditableListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableListBox), new FrameworkPropertyMetadata(typeof(EditableListBox)));
        }
    }
}
