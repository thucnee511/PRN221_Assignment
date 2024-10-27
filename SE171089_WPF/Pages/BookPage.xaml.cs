using SE171089_BusinessObject;
using SE171089_Services.BookService;
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
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        private IBookService _bookService;
        private Book _selectedBook;
        public BookPage()
        {
            InitializeComponent();
            _bookService = BookService.Instance;
            LoadData(_bookService.GetBooks());
        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var columnsToHide = new List<string> { "RentDetails", "CateId" };
            if (columnsToHide.Contains(e.Column.Header.ToString()))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyType == typeof(Category))
            {
                e.Column.Header = "Category";
                if (e.Column is DataGridBoundColumn boundColumn)
                {
                    boundColumn.Binding = new Binding("Cate.Name");
                }
            }
            if (e.Column.Header.ToString() == "Category")
            {
                e.Column.DisplayIndex = 2;
            }
        }
        private void LoadData(List<Book> books)
        {
            dtgBookData.ItemsSource = books;
            List<Category> categories = _bookService.GetCategories();
            cbSearchCategory.ItemsSource = categories;
            cbSearchCategory.DisplayMemberPath = "Name";
        }
        private void DisplayBookInfo()
        {
            if (_selectedBook != null)
            {
                txtName.Text = _selectedBook.Name;
                txtTitle.Text = _selectedBook.Title;
                txtDescription.Text = _selectedBook.Description;
                txtQuantity.Text = _selectedBook.Quantity.ToString();
                cbCategory.ItemsSource = _bookService.GetCategories();
                cbCategory.DisplayMemberPath = "Name";
                cbCategory.SelectedIndex = _selectedBook.Cate.Id -1;
            }
        }
        private void dtgBookData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = dtgBookData.SelectedItem as Book;
            DisplayBookInfo();
        }
    }
}
