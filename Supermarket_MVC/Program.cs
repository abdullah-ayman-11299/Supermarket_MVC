using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using System.Net.Mime;
using System.Text;
using UseCases.CategoriesUseCases;
using UseCases.CategoriesUseCases.Interfaces;
using UseCases.DataStorePluginInterface;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;
using UseCases.TransactionsUseCases.Interfaces;
using Microsoft.AspNetCore.Identity;
using Supermarket_MVC.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement"));
});
builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Inventories", p => p.RequireClaim("Position", "Inventory"));
    options.AddPolicy("Cashiers", p => p.RequireClaim("Position", "Cashier"));
});

if(builder.Environment.IsEnvironment("QA"))
{
    builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
    builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
    builder.Services.AddSingleton<ITransactionRepository, TransactionInMemoryRepository>();
}
else
{
    builder.Services.AddTransient<ICategoryRepository, CategorySqlRepository>();
    builder.Services.AddTransient<IProductRepository, ProductSqlRepository>();
    builder.Services.AddTransient<ITransactionRepository, TransactionSqlRepository>();
}

//Categories - DI
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
//Products - DI
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryUseCase, ViewProductsByCategoryUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<ISelectedProductUseCase, SelectedProductUseCase>();
//Transaction -DI
builder.Services.AddTransient<IViewTransactionsByDayAndCashier, ViewTransactionsByDayAndCashier>();
builder.Services.AddTransient<ITransactionsSearch, TransactionsSearch>();
builder.Services.AddTransient<IAddTransaction,AddTransaction>();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name:"default",
    pattern: "{Controller=Home}/{action=Index}/{id?}");

app.Run();
