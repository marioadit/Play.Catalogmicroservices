using Play.Catalog.Service.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Play.Catalog.Service.Settings;
using Play.Catalog.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Configure GuidRepresentation
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

// Add services to the container.
builder.Services.AddControllers(
    options => options.SuppressAsyncSuffixInActionNames = false
);
//builder.Services.AddMongo().AddMongoRepository<Item>("items");
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add swagger
builder.Services.AddSwaggerGen();

builder.Services.AddMongo().AddMongoRepository<Item>("items");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
