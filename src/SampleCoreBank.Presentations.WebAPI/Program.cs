using SampleCoreBank.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddMiddleware(builder.Configuration, typeof(Program).Assembly);

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
		options.JsonSerializerOptions.MaxDepth = 5; // aumenta profundidade se necessário
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
		options.JsonSerializerOptions.WriteIndented = true;
		Console.WriteLine("JSON Serializer configurado");
	});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware();

app.Run();
