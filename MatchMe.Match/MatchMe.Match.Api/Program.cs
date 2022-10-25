using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.MongoDb;
using MatchMe.Match.Infrastructure;
using MatchMe.Match.Integration;
using MatchMe.Match.Integration.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddJwtAuthentication("MatchMe.Match.Api", "v1");

builder.Services.AddMongo()
    .AddMongoRepository<OpportunityCreatedMessageDto>("Opportunities")
    .AddMongoRepository<CandidateCreatedMessageDto>("Candidates");

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
