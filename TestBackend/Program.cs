//https://localhost:7169/report/info?user=b28d0ced-8af5-4c94-8650-c7946241fd1a&query=1a98b57d-e090-4d18-8654-678e463b73e8

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
