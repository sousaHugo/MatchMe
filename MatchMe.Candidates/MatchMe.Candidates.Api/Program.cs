using MatchMe.Candidates.Application;
using MatchMe.Candidates.Infrastructure;
using MatchMe.Candidates.Integration;
using MatchMe.Common.Shared.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options => { options.SuppressAsyncSuffixInActionNames = false; }).AddNewtonsoftJson();
builder.Services.AddJwtAuthentication("MatchMe.Candidates.Api", "v1");
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddShared();
builder.Services.AddIntegration();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

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
