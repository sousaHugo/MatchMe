using MatchMe.Common.Shared.Extensions;
using MatchMe.Match.Infrastructure;
using MatchMe.Match.Integration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddJwtAuthentication("MatchMe.Match.Api", "v1");
builder.Services.AddShared();
builder.Services.AddIntegration();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

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
