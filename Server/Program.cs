using BlazorApp1.Server.Data;
using BlazorApp1.Server.ServiceServerAluno;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Habilita sqllocal
string _connectionString2 = null!;
_connectionString2 = "Server=.\\SQLExpress;DataBase=Alunos1;Trusted_Connection=True;TrustServerCertificate=true";
builder.Services.AddDbContext<DataContext>(options => { _ = options.UseSqlServer(_connectionString2); });
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IServiceAluno, ServiceAluno>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
