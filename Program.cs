using myfinance_web_dotnet;
using myfinance_web_dotnet.Application.ObterPlanoConta;
using myfinance_web_dotnet.Services.Interfaces;
using myfinance_web_dotnet.Repository.Interfaces;
using myfinance_web_dotnet.Repository;
using myfinance_web_dotnet.Service.PlanoContaService;
using myfinance_web_dotnet.Application.CadastrarPlanoConta;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyFinanceDbContext>();

builder.Services.AddScoped<IObterPlanoConta,ObterPlanoConta>();
builder.Services.AddScoped<ICadastrarPlanoConta,CadastrarPlanoConta>();
builder.Services.AddScoped<IPlanoContaService,PlanoContaService>();
builder.Services.AddScoped<IPlanoContaRepository,PlanoContaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
