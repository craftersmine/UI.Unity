using craftersmine.Ui.Unity.Controls;

using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace craftersmine.Ui.Unity.DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EditableListBox_AddClick(object sender, RoutedEventArgs e)
        {
            EditableListBox? lb = sender as EditableListBox;
            if (lb is null)
                return;
            lb.Items.Add("New Item!");
        }

        private void EditableListBox_RemoveClick(object sender, RoutedEventArgs e)
        {
            EditableListBox? lb = sender as EditableListBox;
            if (lb is null)
                return;
            if (lb.SelectedItem is null)
                return;
            lb.Items.Remove(lb.SelectedItem);
        }

        private void UnityColorPicker_Click(object sender, RoutedEventArgs e)
        {
            UnityColorPicker picker = (UnityColorPicker)sender;
            Color color = new Color();
            byte[] colorData = RandomNumberGenerator.GetBytes(4);
            color.R = colorData[0];
            color.G = colorData[1];
            color.B = colorData[2];
            color.A = colorData[3];
            picker.Color = color;
        }
    }
}