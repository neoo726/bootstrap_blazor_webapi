using DataView_UMS.Components;
using DataView_UMS.Components.Pages;
using DataView_UMS.Data;
using Microsoft.AspNetCore.SignalR;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddControllers();

builder.Services.AddBootstrapBlazor();

builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddResponseCompression();
// 增加 Table 数据服务操作类
builder.Services.AddTableDemoDataService();

// 增加 SignalR 服务数据传输大小限制配置
builder.Services.Configure<HubOptions>(option => option.MaximumReceiveMessageSize = null);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "DataView UMS", Version = "v1" });
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UseResponseCompression();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataView UMS V1");
    c.RoutePrefix = "docs";
});

app.UseStaticFiles();

app.MapControllers();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
Console.ReadKey();
