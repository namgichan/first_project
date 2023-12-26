var builder = WebApplication.CreateBuilder(args);
//웹서버가 실행될때 먼저 실행되는 프로그램
// Add services to the container.
builder.Services.AddRazorPages();//추가한 구문
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
app.UseStaticFiles();//정적 파일 서비스 

app.UseRouting();//주소를 매핑

app.UseAuthorization();// 인증 

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NewsCRUD}/{action=Home}/{id?}");//id변수 입력
app.MapControllerRoute(
    name: "Student",
    pattern: "{controller=Student}/{action=Edit}/{id?}");//id변수 입력

app.Run();
