using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    //Add DI
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

/***********************************/
/***********************************/
/*Use these lines if yuo want Global Error Handling via Exception Filter Attribute*/
    // Add services to the container.
    // builder.Services.AddControllers(
    //     options => 
    //             options.Filters.Add<ErrorHandlingFilterAttribute>()
    // );
/***********************************/

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailFactory>();
 
    // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //Use the below line if you want Global Error Handling via Middleware
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    
    /********************************************************************************/
    //Use the lines below if you want Global Error Handling via Error EndPoint
    app.UseExceptionHandler("/error");

    // app.Map("/error", (HttpContext httpContext)=> {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem();
    // });
/*************************************************************************************/
    app.UseHttpsRedirection();

    // app.UseAuthorization();

    app.MapControllers();

    app.Run();
}