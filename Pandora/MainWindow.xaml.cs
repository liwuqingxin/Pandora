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
using Pandora.Apps;

namespace Pandora
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ActiveKeeper _activeKeeper = new ActiveKeeper();
        public MainWindow()
        {
            InitializeComponent();


        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;
            if (cb.IsChecked == true)
            {
                _activeKeeper.Begin();
            }
            else
            {
                _activeKeeper.Stop();
            }
        }
    }
}
