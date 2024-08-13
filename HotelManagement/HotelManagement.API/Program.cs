using HotelManagement.API.Extensions;
using HotelManagement.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureHotelService();
builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureMappingProfile();

builder.Services.AddSwaggerDocument(configure =>
{
    configure.PostProcess = (doc =>
    {
        doc.Info.Title = "Hotel Management";
        doc.Info.Version = "10.1";
        doc.Info.Description = "All Hotels in Azerbaijan";
        doc.Info.Contact = new NSwag.OpenApiContact()
        {
            Name = "Nurlan Jabiev",
            Url = "https://www.youtube.com/@iamjabiev",
            Email = "jabieviam@gmail.com",
        };
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}
app.MapGet("/", handler =>
{
    handler.Response.Redirect("/swagger/index.html", permanent: false);
    return Task.CompletedTask;
});
app.MapControllers();

app.Run();