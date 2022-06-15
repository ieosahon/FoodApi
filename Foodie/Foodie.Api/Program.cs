using Foodie.Application.Services;
using Foodie.Infrastructure.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddControllers();

    builder.Services.AddApplicationService();

    // to register your own services, add them to the container
    
    builder.Services.AddInfrastructure();
}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}


//app.UseAuthorization();


