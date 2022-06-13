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

namespace Wypozyczalnia
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow Navigate = new NavigationWindow();

            Navigate.Navigate(new Uri("Page1.xaml",UriKind.Relative));


            /*LoggedInWindow loggedInWindow = new LoggedInWindow();
            loggedInWindow.Owner = this;
            loggedInWindow.Show();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this;
            mainWindow.Close();*/


        }
    }
}
