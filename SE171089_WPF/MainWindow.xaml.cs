using Microsoft.EntityFrameworkCore;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ActiveButton(object button)
        {
            Button clickedButton = (Button) button;
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
            Application.Current.Shutdown();
        }
    }
}
