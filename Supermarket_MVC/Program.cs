using Microsoft.AspNetCore.Mvc.Formatters;
//using Plugins.DataStore.InMemory;
using System.Net.Mime;
using System.Text;
//using UseCases.CategoriesUseCases;
//using UseCases.CategoriesUseCases.Interfaces;
//using UseCases.DataStorePluginInterface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();

//builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
//builder.Services.AddTransient<IViewCategoriesUseCase,ViewCategoriesUseCase>();
//builder.Services.AddTransient<IAddCategoryUseCase,AddCategoryUseCase>();
//builder.Services.AddTransient<IEditCategoryUseCase,EditCategoryUseCase>();
//builder.Services.AddTransient<IDeleteCategoryUseCase,DeleteCategoryUseCase>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name:"default",
    pattern: "{Controller=Home}/{action=Index}/{id?}");

app.Run();
