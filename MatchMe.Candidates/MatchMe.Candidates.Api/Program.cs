using Mapster;
using MatchMe.Candidates.Application;
using MatchMe.Candidates.Application.Dto.Candidates.Mappings;
using MatchMe.Candidates.Domain.Events;
using MatchMe.Candidates.Infrastructure;
using MatchMe.Common.Shared.Domain;
using MatchMe.Common.Shared.Extensions;
using MatchMe.Common.Shared.Integration.Opportunities;
using MatchMe.Common.Shared.MongoDb;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongo()
    .AddMongoRepository<DomainEvent>("Events");

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();

CandidateToCandidateDtoMapperConfig.Configure();
TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseShared();

app.UseAuthorization();

app.MapControllers();

app.Run();
