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
using System.Windows.Shapes;

namespace Wpf_Karaokay
{
    /// <summary>
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Window
    {
        public EditMenu()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public void clearData()
        {
            txtItemID.Clear();
            txtItemName.Clear();
            txtItemType.Clear();
            txtItemPrice.Clear();
        }
    }
}
