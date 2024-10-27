using Microsoft.EntityFrameworkCore;
using SE171089_BusinessObject;
using SE171089_WPF.Pages;
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

namespace SE171089_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button activeButton;
        private Account CurrentAccount { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            frMain.Content = new LoginPage(AccessControl);
        }
        private void ActiveButton(object button)
        {
            Button clickedButton = (Button)button;
            if (activeButton != null)
            {
                activeButton.Background = Brushes.AliceBlue;
                activeButton.BorderBrush = Brushes.AliceBlue;
                activeButton.Foreground = Brushes.Black;
            }
            clickedButton.Background = Brushes.White;
            clickedButton.BorderBrush = Brushes.White;
            clickedButton.Foreground = Brushes.Black;
            activeButton = clickedButton;
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (button != activeButton)
            {
                button.Background = Brushes.White;
                button.BorderBrush = Brushes.White;
                button.Foreground = Brushes.Black;
            }
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (button != activeButton)
            {
                button.Background = Brushes.AliceBlue;
                button.BorderBrush = Brushes.AliceBlue;
                button.Foreground = Brushes.Black;
            }
        }
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            ActiveButton(sender);
            frMain.Content = new UserPage(CurrentAccount);
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            ActiveButton(sender);
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            ActiveButton(sender);
        }

        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            ActiveButton(sender);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Do you want to exit the app?", "Exit App!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void AccessControl(Account account)
        {
            CurrentAccount = account;
            int role = CurrentAccount.RoleId;
            if (role == 1 || role == 2)
            {
                frMain.Margin = new Thickness(200, 100, 0, 0);
                btnBook.Visibility = Visibility.Visible;
                btnRent.Visibility = Visibility.Visible;
                btnUser.Visibility = Visibility.Visible;
                btnQuit.Visibility = Visibility.Visible;
                ActiveButton(btnUser);
                frMain.Content = new UserPage(CurrentAccount);
            }
            else
            {
                MessageBoxResult answer = MessageBox.Show("You don't have permission to access this application!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                if (answer == MessageBoxResult.OK)
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
