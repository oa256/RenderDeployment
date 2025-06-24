using RenderTestApi.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(StudentMapperProfile));


var app = builder.Build();


app.MapGet("/", () => "Hello from Render!");

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
app.UseSwagger();
app.UseSwaggerUI();
/*}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Set Render.com port
var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
app.Urls.Add($"http://*:{port}");


app.Run();
