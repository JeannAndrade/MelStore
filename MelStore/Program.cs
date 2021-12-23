using FluentValidation.AspNetCore;
using MelStore.Extensions;
using MelStore.Infraetructure.Binders;
using NLog;

//Configure Logging
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();

builder.Services.ConfigureRepositoryManager();

//Add services to the container
builder.Services.AddControllersWithViews(options =>
{
  options.ModelBinderProviders.Insert(0, new DecimalBinderProvider());
}).AddFluentValidation();

builder.Services.ConfigureLoggerService();
builder.Services.ConfigureDateProvider();
builder.Services.ConfigureFluentValidator();
builder.Services.ConfigureCommandsAndQueries();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MelStore.Infraetructure.Mappings.MappingProfile));

var app = builder.Build();

//Configure the HTTP request pipeline
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
  endpoints.MapDefaultControllerRoute();
});

app.Run();
