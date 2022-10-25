using MatchMe.Common.Shared.Extensions;
using MatchMe.Opportunities.Application;
using MatchMe.Opportunities.Infrastructure;
using MatchMe.Opportunities.Integration;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;

}).AddNewtonsoftJson();

builder.Services.AddJwtAuthentication("MatchMe.Opportunities.Api", "v1");

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddIntegration();
builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseShared();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
