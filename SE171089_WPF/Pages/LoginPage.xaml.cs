using SE171089_BusinessObject;
using SE171089_Services.AccountService;
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

namespace SE171089_WPF.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly IAccountService _accountService;
        private Action<Account> AccessControl;
        public LoginPage(Action<Account> AccessControl)
        {
            InitializeComponent();
            _accountService = AccountService.Instance;
            this.AccessControl = AccessControl;
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Do you want to exit the app?", "Exit App!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            try
            {
                Account account = _accountService.Login(email, password);
                AccessControl(account);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
