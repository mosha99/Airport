var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AirplantContext>(ServiceLifetime.Transient);
builder.Services.AddTransient<IReadRepasitory, ReadRepasitory>();
builder.Services.AddTransient<IQueueRepasitory, QueueRepasitory>();
builder.Services.AddTransient<ISimpelWrite, SimpelWrite>();
builder.Services.AddTransient<IWorkRepository, WorkRepository>();


var sp = builder.Services.BuildServiceProvider();
Worker worker = new Worker(sp);

builder.Services.AddSingleton(typeof(Worker), worker);

//builder.Logging.AddFilter((a, Loglevel) => { if (Loglevel != LogLevel.Error ) return false; else return true; });


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
