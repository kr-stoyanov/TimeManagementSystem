using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.MongoDb;
using Plugins.DataStore.MongoDb.Models;
using UseCases.UseCaseInterfaces;
using UseCases.DataStorePluginInterfaces;
using WebApp.ViewModels;
using UseCases.TimeCardUseCases;
using UseCases.ProjectUseCases;
using UseCases.Report;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection for In-Memory Data Store
//builder.Services.AddScoped<ITimeCardInMemoryRepository, TimeCardInMemoryRepository>();

//Dependency Injection for MongoDb DataStore
builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
builder.Services.AddSingleton<ITimeCardMongoDbRepository, TimeCardMongoDbRepository>();
builder.Services.AddSingleton<IProjectMongoDbRepository, ProjectMongoDbRepository>();


//Database configuration settings - MongoDb
builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);

var mongoDbIdentityConfig = new MongoDbIdentityConfiguration
{
    MongoDbSettings = new MongoDbSettings
    {
        ConnectionString = builder.Configuration
                            .GetSection(nameof(DatabaseSettings)).GetSection("ConnectionString").Value,
        DatabaseName = builder.Configuration
                            .GetSection(nameof(DatabaseSettings)).GetSection("DatabaseName").Value
    },
    IdentityOptionsAction = options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    }
};

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
    (
        mongoDbIdentityConfig.MongoDbSettings.ConnectionString,
        mongoDbIdentityConfig.MongoDbSettings.DatabaseName
    )
    .AddDefaultTokenProviders();

builder.Services.AddOptions();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication().AddCookie();


//Dependency Injection for UseCases and Repositories
builder.Services.AddTransient<ITimeCardViewModel, TimeCardViewModel>();
builder.Services.AddTransient<IAddProjectUseCase, AddProjectUseCase>();
builder.Services.AddTransient<IEnumHelperUseCase, EnumHelperUseCase>();
builder.Services.AddTransient<IEditProjectUseCase, EditProjectUseCase>();
builder.Services.AddTransient<IAddTimeCardUseCase, AddTimeCardUseCase>();
builder.Services.AddTransient<IEditTimeCardUseCase, EditTimeCardUseCase>();
builder.Services.AddTransient<IViewProjectsUseCase, ViewProjectsUseCase>();
builder.Services.AddTransient<IGetProjectByIdUseCase, GetProjectByIdUseCase>();
builder.Services.AddTransient<IGetTimeCardByIdUseCase, GetTimeCardByIdUseCase>();
builder.Services.AddTransient<IViewReportByUserUseCase, ViewReportByUserUseCase>();
builder.Services.AddTransient<IViewTimeCardsByUserUseCase, ViewTimeCardsByUserUseCase>();
builder.Services.AddTransient<ITimeCardHistoryByUserUseCase, TimeCardHistoryByUserUseCase>();

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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
