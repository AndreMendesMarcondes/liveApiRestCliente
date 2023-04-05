using AE.API.Config;
using LARC.Data.Repositories;
using LARC.Domain.Interfaces.Repositories;
using LARC.Domain.Interfaces.Services;
using LARC.Domain.Settings;
using LARC.Service.Services;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.AddSerilog(builder);
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
