//using Microsoft.EntityFrameworkCore;
//using TodoApi.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//


using MongoDB.Driver;
using MongoDB.Bson;

const string connectionUri = "mongodb+srv://admin:dWA7qRfDWmLrYZiQ@cluster0.s3oc7sn.mongodb.net/?retryWrites=true&w=majority";

var settings = MongoClientSettings.FromConnectionString(connectionUri);

// Set the ServerApi field of the settings object to Stable API version 1
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

// Create a new client and connect to the server
var client = new MongoClient(settings);

// Send a ping to confirm a successful connection
try
{
    var dbInstance = client.GetDatabase("sample_mflix");
    var result = dbInstance.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
    Console.WriteLine("Hola mundo");
    Console.WriteLine(result);
    var collection = dbInstance.GetCollection<BsonDocument>("movies");
    var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
    var document = collection.Find(filter).First();

    Console.WriteLine(document);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

