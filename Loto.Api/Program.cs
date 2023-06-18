using Microsoft.EntityFrameworkCore;
using Loto.Infrastructure.Context;
using Loto.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region "App Dependencies"

builder.Services.AddContextDependency(builder.Configuration.GetConnectionString("LotoContext"));

builder.Services.AddBranchDependency();


////builder.Services.AddSecurityDependency();

#endregion


#region "Swagger Config"
builder.Services.AddSwaggerGen();

#endregion


#region "Token Info"
builder.Services.AddAuthentication(jb =>
{
    //jb.DefaultAuthenticateScheme= 
});
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
