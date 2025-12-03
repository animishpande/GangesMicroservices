var builder = WebApplication.CreateBuilder(args);

// Add services to the container before building the application
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the http request pipeline
app.MapCarter();

app.Run();
