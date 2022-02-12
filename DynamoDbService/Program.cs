using Amazon;
using Amazon.DynamoDBv2;
using DynamoDbService.DynamoServices;
using DynamoDbService.Entity;
using DynamoDbService.Interfaces;
using DynamoDbService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IResultadointegracaoDynamoDb, ResultadointegracaoDynamoDb>();

//Configurar serviço AWS
var clientConfig = new AmazonDynamoDBConfig()
{
    RegionEndpoint = RegionEndpoint.USEast1,
    ServiceURL = "http://localhost:8042"
};

builder.Services.AddScoped<IDynamoDbContext<ResultadoIntegracaoEntity>>(provider => 
                new DynamoDbContext<ResultadoIntegracaoEntity>(new AmazonDynamoDBClient(clientConfig)));


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


