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
        public UserPage()
        {
            InitializeComponent();
            _accountService = AccountService.Instance;
            LoadData();
        }
        private void LoadData()
        {
            List<Account> accounts = _accountService.GetAccounts();
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
    }
}
