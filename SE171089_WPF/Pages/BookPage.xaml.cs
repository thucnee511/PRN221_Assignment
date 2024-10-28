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
            cbCategory.ItemsSource = _bookService.GetCategories();
            cbCategory.DisplayMemberPath = "Name";
        }
        private void DisplayBookInfo()
        {
            if (_selectedBook != null)
            {
                txtName.Text = _selectedBook.Name;
                txtTitle.Text = _selectedBook.Title;
                txtDescription.Text = _selectedBook.Description;
                txtQuantity.Text = _selectedBook.Quantity.ToString();
                cbCategory.SelectedIndex = _selectedBook.Cate.Id - 1;
            }
        }
        private void dtgBookData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = dtgBookData.SelectedItem as Book;
            DisplayBookInfo();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                string name = txtName.Text;
                string description = txtDescription.Text;
                int quantity = int.Parse(txtQuantity.Text);
                int cateId = cbCategory.SelectedIndex + 1;
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
                {
                    throw new Exception("Title, Name and Description are required!!!");
                }
                if (quantity <= 0)
                {
                    throw new Exception("Quantity must be greater than 0!!!");
                }
                if (cateId <= 0)
                {
                    throw new Exception("Category is required!!!");
                }
                Book book = new Book
                {
                    Name = name,
                    Title = title,
                    Description = description,
                    Quantity = quantity,
                    CateId = cateId
                };
                _selectedBook = _bookService.AddBook(book);
                LoadData(_bookService.GetBooks());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int cateId = cbSearchCategory.SelectedIndex + 1;
            string keyword = txtSearch.Text;
            List<Book> books = _bookService.Search(keyword, cateId);
            LoadData(books);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedBook == null)
                {
                    throw new Exception("Please select a book to update!!!");
                }
                string title = txtTitle.Text;
                string name = txtName.Text;
                string description = txtDescription.Text;
                int quantity = int.Parse(txtQuantity.Text);
                int cateId = cbCategory.SelectedIndex + 1;
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
                {
                    throw new Exception("Title, Name and Description are required!!!");
                }
                if (quantity <= 0)
                {
                    throw new Exception("Quantity must be greater than 0!!!");
                }
                if (cateId <= 0)
                {
                    throw new Exception("Category is required!!!");
                }
                _selectedBook.Name = name;
                _selectedBook.Title = title;
                _selectedBook.Description = description;
                _selectedBook.Quantity = quantity;
                _selectedBook.CateId = cateId;
                _selectedBook = _bookService.Update(_selectedBook);
                LoadData(_bookService.GetBooks());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
