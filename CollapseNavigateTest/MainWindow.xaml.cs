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
using CollapseNavigateTest.ViewModel;

namespace CollapseNavigateTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (BtnOpenMenu.Visibility == Visibility.Visible)
            {
                BtnOpenMenu.Visibility = Visibility.Collapsed;
                BtnCloseMenu.Visibility = Visibility.Visible;
            }

            else if (BtnOpenMenu.Visibility == Visibility.Collapsed)
            {
                BtnOpenMenu.Visibility = Visibility.Visible;
                BtnCloseMenu.Visibility = Visibility.Collapsed;
            }
        }
    }
}
