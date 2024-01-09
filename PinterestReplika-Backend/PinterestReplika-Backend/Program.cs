using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PinterestReplika_Core.Models;
using PinterestReplika_DataAccess.Contexts;
using PinterestReplika_Repositories;
using PinterestReplika_Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddSingleton<IPostMetadataRepository, PostMetadataRepository>();

// Add DBContext

builder.Services.AddDbContext<PinterestReplikaSqlDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<PinterestReplikaSqlDbContext>();

// Add connection to MongoDB
builder.Services.Configure<PinterestReplikaDbMongoSettings>(builder.Configuration.GetSection("PinterestReplikaDatabaseSettings"));
builder.Services.AddSingleton<IMongoClient>(_ => {
    var connectionString =
        builder
            .Configuration
            .GetSection("PinterestReplikaDatabaseSettings:ConnectionString")?
            .Value;
    return new MongoClient(connectionString);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
