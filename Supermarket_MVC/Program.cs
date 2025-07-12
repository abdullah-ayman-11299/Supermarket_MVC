using Microsoft.AspNetCore.Mvc.Formatters;
using Plugins.DataStore.InMemory;
using System.Net.Mime;
using System.Text;
using UseCases.CategoriesUseCases;
using UseCases.CategoriesUseCases.Interfaces;
using UseCases.DataStorePluginInterface;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;
using UseCases.TransactionsUseCases.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
builder.Services.AddSingleton<IProductRepository , ProductsInMemoryRepository>();
builder.Services.AddSingleton<ITransactionRepository , TransactionInMemoryRepository>();

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
app.MapControllerRoute(
    name:"default",
    pattern: "{Controller=Home}/{action=Index}/{id?}");

app.Run();
