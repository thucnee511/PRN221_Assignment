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

namespace SE171089_WPF.Pages.UserPages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly IAccountService _accountService;
        private Account _selectedAccount;
        public UserPage()
        {
            InitializeComponent();
            _accountService = AccountService.Instance;
            LoadData(_accountService.GetAccounts());
        }
        private void LoadData(List<Account> accounts)
        {
            dtgUsers.ItemsSource = accounts;
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var columnsToHide = new List<string> { "Role", "Rents", "Password" };
            if (columnsToHide.Contains(e.Column.Header.ToString()))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
        private void dtgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            _selectedAccount = dataGrid.SelectedItem as Account;
            if(_selectedAccount != null)
            {
                ChangeInfoContent();
            }
        }
        private void ChangeInfoContent()
        {
            txtUsername.Text = _selectedAccount.Username;
            txtEmail.Text = _selectedAccount.Email;
            txtPassword.Password = _selectedAccount.Password;
            txtRole.Text = _accountService.GetRoleName(_selectedAccount.RoleId);
            txtStatus.Text = _selectedAccount.Status == 1 ? "Active" : "Inactive";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text;
            List<Account> accounts = _accountService.Search(keyword);
            LoadData(accounts);
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                Account user = _accountService.GetByUsername(username);
                if (user != null)
                {
                    throw new Exception("Username already exists!!!");
                }
                user = _accountService.GetByEmail(email);
                if (user != null)
                {
                    throw new Exception("Email already exists!!!");
                }
                Account account = new Account() {
                    Username = username,
                    Email = email,
                    Password = "12345678",
                    RoleId = 3,
                    Status = 1
                };
                _accountService.Insert(account);
            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
