using ParcelCalculator.Interfaces;
using ParcelCalculator.Middlewares;
using ParcelCalculator.Services;
using ParcelCalculator.Strategies;
using System.Reflection;

namespace ParcelCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddScoped<ICostService, CostService>();
            builder.Services.AddScoped<IPricingStrategy, RejectedParcelStrategy>();
            builder.Services.AddScoped<IPricingStrategy, HeavyParcelStrategy>();
            builder.Services.AddScoped<IPricingStrategy, SmallParcelStrategy>();
            builder.Services.AddScoped<IPricingStrategy, MediumParcelStrategy>();
            builder.Services.AddScoped<IPricingStrategy, LargeParcelStrategy>();

            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
