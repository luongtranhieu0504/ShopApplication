using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Interface;
using ShopApplication.Repository;

namespace ShopApplication
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			/*builder.Services.AddTransient<SeedData>();*/
			/*			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			*/
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<DataContext>(options =>
				options.UseNpgsql("User Id=postgres.pepiwahqzfqojffolhaq;Password=helloworld@siu2003k14;Server=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;"));


			var app = builder.Build();

			/*if (args.Length == 1 && args[0].ToLower() == "seeddata")
				SeedData(app);

			void SeedData(IHost app)
			{
				var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

				using (var scope = scopedFactory.CreateScope())
				{
					var service = scope.ServiceProvider.GetService<SeedData>();
					service.SeedDataContext();
				}
			}*/

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