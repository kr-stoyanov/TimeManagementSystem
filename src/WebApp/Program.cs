using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.MongoDb;
using Plugins.DataStore.MongoDb.Models;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;
using WebApp.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Dependency Injection for In-Memory Data Store
//builder.Services.AddScoped<ITimeCardInMemoryRepository, TimeCardInMemoryRepository>();

//Dependency Injection for MongoDb DataStore
builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
builder.Services.AddSingleton<ITimeCardMongoDbRepository, TimeCardMongoDbRepository>();

//Database configuration settings - MongoDb
builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

//Dependency Injection for UseCases and Repositories
builder.Services.AddTransient<IEnumHelperUseCase, EnumHelperUseCase>();
builder.Services.AddTransient<IAddTimeCardUseCase, AddTimeCardUseCase>();
builder.Services.AddTransient<IEditTimeCardUseCase, EditTimeCardUseCase>();
builder.Services.AddTransient<IViewTimeCardsUseCase, ViewTimeCardsUseCase>();
builder.Services.AddTransient<ITimeCardHistoryUseCase, TimeCardHistoryUseCase>();
builder.Services.AddTransient<IGetTimeCardByIdUseCase, GetTimeCardByIdUseCase>();
builder.Services.AddTransient<ITimeCardViewModel, TimeCardViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
