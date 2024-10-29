using SE171089_Services.AccountService;
using SE171089_Services.BookService;
using SE171089_Services.RentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddSingleton<IAccountService>(AccountService.Instance);
builder.Services.AddSingleton<IBookService>(BookService.Instance);
builder.Services.AddSingleton<IRentService>(RentService.Instance);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
