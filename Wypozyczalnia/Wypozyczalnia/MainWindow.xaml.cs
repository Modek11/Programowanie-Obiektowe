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
using MaterialDesignThemes.Wpf;


namespace Wypozyczalnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool isDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper=new PaletteHelper();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if(isDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                isDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                isDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            using (WypozyczalniaEntities db = new WypozyczalniaEntities())
            {
                string insertedEmail = txtUsername.Text;
                string insertedPassword = txtPassword.Password;

                foreach (var user in db.Uzytkownicy)
                {
                    if (insertedEmail == user.Email)
                    {
                        if (insertedPassword == user.Haslo)
                        {
                            infoText.Text = "Zalogowano poprawnie!";
                            return;
                        }
                        else
                        {
                            infoText.Text = "Błędne hasło!";
                            return;
                        }
                    }
                }
                infoText.Text = "Błędny email!";
            }
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /*private void Register() //TODO
        {
            using (WypozyczalniaEntities db = new WypozyczalniaEntities())
            {
                string insertedName = ;
                string insertedSurname = ;
                string insertedEmail = ;
                string insertedPassword = ;
                string insertedPESEL = ;
                bool parsedPhoneNumber = Int32.TryParse(Console.ReadLine().Trim(), out int insertedPhoneNumber);
                bool parsedDrivingLicenseYears = short.TryParse(Console.ReadLine().Trim(), out short insertedDrivingLicenseYears);

                if (!parsedPhoneNumber || !parsedDrivingLicenseYears)
                {
                    Console.WriteLine("Podano złe liczby w formularzu!");
                    return;
                }

                if (insertedPhoneNumber < 100000000 || insertedPhoneNumber > 999999999)
                {
                    Console.WriteLine("Podany numer telefonu jest błędny!");
                    return;
                }

                foreach (var user in db.Uzytkownicy)
                {
                    if (insertedEmail == user.Email)
                    {
                        Console.WriteLine("Podany E-mail już istnieje!");
                        return;
                    }
                    if (insertedPESEL == user.PESEL)
                    {
                        Console.WriteLine("Podany PESEL już istnieje!");
                        return;
                    }
                    if (insertedPhoneNumber == user.NrTelefonu)
                    {
                        Console.WriteLine("Podany numer telefonu już istnieje!");
                        return;
                    }
                }

                db.Uzytkownicy.Add(new Uzytkownicy { Imie = insertedName, Nazwisko = insertedSurname, PESEL = insertedPESEL, NrTelefonu = insertedPhoneNumber, Email = insertedEmail, Haslo = insertedPassword, LataPrawaJazdy = insertedDrivingLicenseYears });
                db.SaveChanges();
                Console.WriteLine("Użytkownik został stworzony");
            }
        }*/

        private void forgotBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
