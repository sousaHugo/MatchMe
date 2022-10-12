using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.Integration.Opportunities;
using MatchMe.Common.Shared.MongoDb;
using MatchMe.Match.Infrastructure;
using MatchMe.Match.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMongo()
    .AddMongoRepository<OpportunityCreatedDto>("Opportunities");
builder.Services.AddShared();
builder.Services.AddIntegration();
builder.Services.AddInfrastructure(builder.Configuration);


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
