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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private readonly IAccountService _accountService;
        private Account _selectedAccount;
        private Account _logedInAccount;
        public UserPage(Account logedInAccount)
        {
            InitializeComponent();
            _accountService = AccountService.Instance;
            LoadData(_accountService.GetActiveAccounts());
            _logedInAccount = logedInAccount;
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
            if (_selectedAccount != null)
            {
                ChangeInfoContent();
            }
        }
        private void ChangeInfoContent()
        {
            txtUsername.Text = _selectedAccount.Username;
            txtEmail.Text = _selectedAccount.Email;
            txtPassword.Password = _selectedAccount.Password;
            txtRole.Text = _selectedAccount.RoleId == 0 ? "" : _accountService.GetRoleName(_selectedAccount.RoleId);
            txtStatus.Text = _selectedAccount.Status == 1 ? "Active" : "Inactive";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text;
            List<Account> accounts = _accountService.Search(keyword);
            LoadData(accounts);
            txtSearch.Text = "";
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
                {
                    throw new Exception("Username and Email are required!!!");
                }
                if (!email.Contains("@") || !email.Contains("."))
                {
                    throw new Exception("Invalid Email!!!");
                }
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
                Account account = new Account()
                {
                    Username = username,
                    Email = email,
                    Password = "12345678",
                    RoleId = 3,
                    Status = 1
                };
                _selectedAccount = _accountService.Insert(account);
                ChangeInfoContent();
                LoadData(_accountService.GetActiveAccounts());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedAccount == null)
                {
                    throw new Exception("Please select an account!!!");
                }
                if (_selectedAccount.RoleId <= _logedInAccount.RoleId)
                {
                    throw new Exception("You dont have permission to change this account!!!");
                }
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
                {
                    throw new Exception("Username and Email are required!!!");
                }
                if (_selectedAccount.Status == 0)
                {
                    throw new Exception("This account is inactive!!!");
                }
                if (!email.Contains("@") || !email.Contains("."))
                {
                    throw new Exception("Invalid Email!!!");
                }
                Account user = _accountService.GetByUsername(username);
                if (user != null && user.Id != _selectedAccount.Id)
                {
                    throw new Exception("Username already exists!!!");
                }
                user = _accountService.GetByEmail(email);
                if (user != null && user.Id != _selectedAccount.Id)
                {
                    throw new Exception("Email already exists!!!");
                }
                _selectedAccount.Username = username;
                _selectedAccount.Email = email;
                _selectedAccount = _accountService.Update(_selectedAccount);
                ChangeInfoContent();
                LoadData(_accountService.GetActiveAccounts());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedAccount == null)
                {
                    throw new Exception("Please select an account!!!");
                }
                if (_selectedAccount.RoleId <= _logedInAccount.RoleId)
                {
                    throw new Exception("You dont have permission to remove  this account!!!");
                }
                if (_selectedAccount.Id == _logedInAccount.Id)
                {
                    throw new Exception("You can't remove your own account!!!");
                }
                if (_selectedAccount.Status == 0)
                {
                    throw new Exception("This account is already inactive!!!");
                }
                _selectedAccount = _accountService.Delete(_selectedAccount.Id);
                ChangeInfoContent();
                LoadData(_accountService.GetActiveAccounts());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
