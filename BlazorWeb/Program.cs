using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();



//Omite el "No es seguro" en el navegador por la falta de certificado de VS
var httpCLientHandler = new HttpClientHandler();
httpCLientHandler.ServerCertificateCustomValidationCallback =
    (message, cert, chain, errors) => true;
builder.Services.AddSingleton(new HttpClient(httpCLientHandler)
{
    BaseAddress = new Uri("https://localhost:7238")
});


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
