using translation.application;
using translation.application.Common.Interfaces;
using translation.infrastructure;
using translation.infrastructure.TranslatorServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITranslator,Translator>();
builder.Services.AddScoped<ITranslatorService, TranslatorService>();
builder.Services.AddSingleton<IAvailableLanguage, AvailableLanguage>();
builder.Configuration.AddJsonFile("appsettings.json",optional:false, reloadOnChange:true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
