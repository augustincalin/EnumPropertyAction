
using System.Text.Json.Serialization;
using EPA.API.Model;
using EPA.API.Validation;
using FluentValidation;

namespace EPA.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = false;
            }

                ).AddJsonOptions(options =>
            {
                //var enumConverter = new JsonStringEnumConverter();
                //options.JsonSerializerOptions.Converters.Add(enumConverter);
                options.JsonSerializerOptions.Converters.Add(new JsonEnumConverter<GenderType>());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IValidator<People>, PeopleValidator>();

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
        }
    }
}