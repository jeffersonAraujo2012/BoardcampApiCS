using BoardcampApiCS.Contexts;
using BoardcampApiCS.Errors;
using BoardcampApiCS.Migrations.AutoUpdate;
using BoardcampApiCS.Resourses.Customers;
using BoardcampApiCS.Resourses.Customers.Validators;
using BoardcampApiCS.Resourses.Games;
using BoardcampApiCS.Resourses.Rentals;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddCustomerValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(GameMapper));

string? MySqlConnectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(MySqlConnectionString);
});

builder.Services.AddGameServices();
builder.Services.AddCustomerServices();
builder.Services.AddRentalServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exception = context.Features.Get<IExceptionHandlerFeature>();

        if (exception is not null)
        {
            if (exception.Error is ConflictError)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(new ErrorDetailsViewModel()
                {
                    Message = exception.Error.Message,
                    StatusCode = context.Response.StatusCode
                }.ToString());
                return;
            }

            if (exception.Error is NotFoundError)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(new ErrorDetailsViewModel()
                {
                    Message = exception.Error.Message,
                    StatusCode = context.Response.StatusCode
                }.ToString());
                return;
            }

            if (exception.Error is BadRequestError)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(new ErrorDetailsViewModel()
                {
                    Message = exception.Error.Message,
                    StatusCode = context.Response.StatusCode
                }.ToString());
                return;
            }
            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Server Internal Error");
        }
    });
});

AutoUpdate.Run(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program {};