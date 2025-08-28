using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace craftersmine.Ui.Unity.StyleSelectors
{
    internal class ToolBarButtonStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            ItemsControl? toolbar = ItemsControl.ItemsControlFromItemContainer(container);
            if (toolbar is null)
                return base.SelectStyle(item, container);

            if (toolbar.Items.Count < 2)
                return base.SelectStyle(item, container);

            int itemIndex = toolbar.Items.IndexOf(item);
            Control itm = (Control)item;
            Setter cornerRadius = (Setter)itm.Style.Setters.FirstOrDefault(s => ((Setter)s).Property == Border.CornerRadiusProperty);
            switch (itemIndex)
            {
                case 0:
                    return base.SelectStyle(item, container);
                default:
                    return base.SelectStyle(item, container);
            }
        }
    }
}
