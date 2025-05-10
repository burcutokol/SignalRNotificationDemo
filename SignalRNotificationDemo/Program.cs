var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.MapHub<NotificationHub>("/notificationHub");
app.MapDefaultControllerRoute();


app.Run();
