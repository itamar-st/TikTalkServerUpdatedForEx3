using webServerAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("HandleCors", builder =>
    {
        builder.SetIsOriginAllowed(param => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("HandleCors");
app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapHub<ChatHub>("/hubs/chat"));

app.Run();
