var builder = WebApplication.CreateBuilder(args);
//�������� ����ɶ� ���� ����Ǵ� ���α׷�
// Add services to the container.
builder.Services.AddRazorPages();//�߰��� ����
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();//���� ���� ���� 

app.UseRouting();//�ּҸ� ����

app.UseAuthorization();// ���� 

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NewsCRUD}/{action=Home}/{id?}");//id���� �Է�
app.MapControllerRoute(
    name: "Student",
    pattern: "{controller=Student}/{action=Edit}/{id?}");//id���� �Է�

app.Run();
