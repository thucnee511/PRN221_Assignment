using SE171089_BusinessObject;
using SE171089_Services.AccountService;
using SE171089_Services.BookService;
using SE171089_Services.RentService;
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
    /// Interaction logic for RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        private IAccountService accountService;
        private IBookService bookService;
        private IRentService rentService;
        public Account SelectedUser { get; set; }
        public Book SelectedBook { get; set; }
        public Rent SelectedRent { get; set; }
        private List<RentDetail> RentDetails;
        public RentDetail SelectedRentDetail { get; set; }
        public RentPage()
        {
            InitializeComponent();
            accountService = AccountService.Instance;
            bookService = BookService.Instance;
            rentService = RentService.Instance;
            LoadInitData();
        }
        private void LoadInitData()
        {
            List<Account> accounts = accountService.GetActiveAccounts();
            List<Book> books = bookService.GetBooks();
            List<Rent> rents = rentService.GetAll();
            List<Category> categories = bookService.GetCategories();
            cbUser.ItemsSource = accounts;
            cbUser.DisplayMemberPath = "Username";
            cbBook.ItemsSource = books;
            cbBook.DisplayMemberPath = "Title";
            dtgRent.ItemsSource = rents;
            cbCategory.ItemsSource = categories;
            cbCategory.DisplayMemberPath = "Name";
            btnAddDetail.IsEnabled = false;
            btnRemoveDetail.IsEnabled = false;
            btnReturnRent.IsEnabled = false;
            btnRemoveRent.IsEnabled = false;
            btnAddRent.IsEnabled = false;
        }
        private void dtgRent_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            List<string> columnsToHide = new List<string> { "RentDetails", "UserId" };
            if (columnsToHide.Contains(e.Column.Header.ToString()))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.Column.Header.ToString() == "User")
            {
                e.Column.DisplayIndex = 2;
            }
            if (e.Column.Header.ToString() == "Status")
            {
                e.Column.DisplayIndex = 3;
            }
            if (e.PropertyType == typeof(Account))
            {
                e.Column.Header = "User";
                if (e.Column is DataGridBoundColumn boundColumn)
                {
                    boundColumn.Binding = new Binding("User.Username");
                }
            }
        }

        private void btnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchUser.Text;
            List<Account> accounts = accountService.Search(keyword);
            cbUser.ItemsSource = accounts;
            cbUser.SelectedIndex = -1;
        }

        private void cbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUser = cbUser.SelectedItem as Account;
            DisplayUserRents();
        }
        private void DisplayUserRents()
        {
            if (SelectedUser == null)
            {
                dtgRent.ItemsSource = rentService.GetAll();
                return;
            }
            List<Rent> rents = rentService.GetRentByUserId(SelectedUser.Id);
            dtgRent.ItemsSource = rents;
        }
        private void btnSearchBook_Click(object sender, RoutedEventArgs e)
        {
            int cateId = cbCategory.SelectedIndex + 1;
            string keyword = txtSearchBook.Text;
            List<Book> books = bookService.Search(keyword, cateId);
            cbBook.ItemsSource = books;
            cbBook.SelectedIndex = -1;
        }

        private void cbBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBook = cbBook.SelectedItem as Book;
        }

        private void dtgRent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRent = dtgRent.SelectedItem as Rent;
            DisplayRent();
        }

        private void DisplayRent()
        {
            if (SelectedRent == null)
            {
                txtRentDate.Text = "";
                txtReturnDate.Text = "";
                txtTotal.Text = "";
                txtStatus.Text = "";
                btnAddDetail.IsEnabled = false;
                btnRemoveDetail.IsEnabled = false;
                dtgRentDetail.ItemsSource = null;
                btnAddRent.IsEnabled = false;
                btnRemoveRent.IsEnabled = false;
                btnReturnRent.IsEnabled = false;
                return;
            }
            txtRentDate.Text = SelectedRent.RentTime == null ? "" : SelectedRent.RentTime.Value.ToString("dd-MM-yyyy");
            txtReturnDate.Text = SelectedRent.ReturnTime == null ? "" : SelectedRent.ReturnTime.Value.ToString("dd-MM-yyyy");
            txtTotal.Text = SelectedRent.TotalQuatity.ToString();
            txtStatus.Text = SelectedRent.Status;
            btnAddDetail.IsEnabled = false;
            btnRemoveDetail.IsEnabled = false;
            dtgRentDetail.ItemsSource = null;
            dtgRentDetail.ItemsSource = rentService.GetRentDetailByRentId(SelectedRent.Id);
            btnAddRent.IsEnabled = false;
            btnRemoveRent.IsEnabled = true;
            btnReturnRent.IsEnabled = true;
        }

        private void dtgRentDetail_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            List<string> columnsToHide = new List<string> { "Rent", "RentId", "BookId" };
            if (columnsToHide.Contains(e.Column.Header.ToString()))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.Column.Header.ToString() == "Book")
            {
                e.Column.DisplayIndex = 2;
            }
            if (e.PropertyType == typeof(Book))
            {
                e.Column.Header = "Book";
                if (e.Column is DataGridBoundColumn boundColumn)
                {
                    boundColumn.Binding = new Binding("Book.Title");
                }
            }
        }

        private void btnNewDetail_Click(object sender, RoutedEventArgs e)
        {
            SelectedRent = null;
            RentDetails = new List<RentDetail>();
            btnAddDetail.IsEnabled = true;
            btnRemoveDetail.IsEnabled = true;
            txtTotal.Text = "";
            txtStatus.Text = "";
            txtRentDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtReturnDate.Text = null;
            dtgRentDetail.ItemsSource = RentDetails;
            btnAddRent.IsEnabled = true;
            btnRemoveRent.IsEnabled = false;
            btnReturnRent.IsEnabled = false;
        }

        private void btnAddDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedBook == null)
                {
                    throw new Exception("Please select a book");
                }
                if (RentDetails.Any(rd => rd.BookId == SelectedBook.Id))
                {
                    RentDetail rd = RentDetails.Single(rd => rd.BookId == SelectedBook.Id);
                    Book book = bookService.GetBookById(SelectedBook.Id);
                    if (rd.Quantity >= book.Quantity)
                    {
                        throw new Exception("The quantity of this book is not enough");
                    }
                    rd.Quantity++;
                }
                else
                {
                    RentDetail rd = new()
                    {
                        BookId = SelectedBook.Id,
                        Book = SelectedBook,
                        Quantity = 1
                    };
                    RentDetails.Add(rd);
                }
                txtTotal.Text = RentDetails.Sum(rd => rd.Quantity).ToString();
                dtgRentDetail.ItemsSource = null;
                dtgRentDetail.ItemsSource = RentDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtgRentDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRentDetail = dtgRentDetail.SelectedItem as RentDetail;
        }

        private void btnRemoveDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedRentDetail == null)
                {
                    throw new Exception("Please select a rent detail");
                }
                RentDetails.Remove(SelectedRentDetail);
                dtgRentDetail.ItemsSource = null;
                dtgRentDetail.ItemsSource = RentDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddRent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedUser == null)
                {
                    throw new Exception("Please select a user");
                }
                if (RentDetails.Count == 0)
                {
                    throw new Exception("Please add at least one book");
                }
                Rent rent = new()
                {
                    UserId = SelectedUser.Id,
                    RentTime = DateTime.Now,
                    ReturnTime = null,
                    TotalQuatity = RentDetails.Sum(rd => rd.Quantity),
                    Status = "renting"
                };
                SelectedRent = rentService.Insert(rent, RentDetails);
                UpdateBooksQuantityAfterRent(SelectedRent);
                DisplayUserRents();
                DisplayRent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateBooksQuantityAfterRent(Rent rent)
        {
            foreach (RentDetail rd in rent.RentDetails)
            {
                Book book = bookService.GetBookById((int)rd.BookId);
                book.Quantity -= rd.Quantity;
                bookService.Update(book);
            }
        }
        private void UpdateBooksQuantityAfterReturn(Rent rent)
        {
            foreach (RentDetail rd in rent.RentDetails)
            {
                Book book = bookService.GetBookById((int)rd.BookId);
                book.Quantity += rd.Quantity;
                bookService.Update(book);
            }
        }

        private void btnReturnRent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedRent == null)
                {
                    throw new Exception("Please select a rent");
                }
                if (SelectedRent.Status == "returned")
                {
                    throw new Exception("This rent has been returned");
                }
                SelectedRent.Status = "returned";
                SelectedRent.ReturnTime = DateTime.Now;
                SelectedRent = rentService.Update(SelectedRent);
                UpdateBooksQuantityAfterReturn(SelectedRent);
                DisplayUserRents();
                DisplayRent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveRent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedRent == null)
                {
                    throw new Exception("Please select a rent");
                }
                if (SelectedRent.Status == "renting")
                {
                    throw new Exception("This rent is renting");
                }
                rentService.Delete(SelectedRent.Id);
                SelectedRent = null;
                DisplayUserRents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
