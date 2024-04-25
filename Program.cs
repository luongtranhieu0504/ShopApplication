using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopApplication.Data;
using ShopApplication.Interface;
using ShopApplication.Repository;
using Supabase;
using System.Text;

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
			var supabaseJwtSecretKey = "U6twGBJEf11mMFk5VscK2w3k7YO9jk3wZZ9k5OyKe+PQ628xvG7I5CGCTXUpMcw8hYXRULF/gmcMn2wui3bOdA==";
			var supabaseSignatureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(supabaseJwtSecretKey));
			var validIssuer = "https://pepiwahqzfqojffolhaq.supabase.co/auth/v1";
			var validAudiences = new List<string> { "authenticated" };
			builder.Services.AddAuthentication().AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = supabaseSignatureKey,
					ValidAudiences = validAudiences,
					ValidIssuer = validIssuer
				};
			});

			var url = "https://pepiwahqzfqojffolhaq.supabase.co";
			var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InBlcGl3YWhxemZxb2pmZm9saGFxIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTM1ODA3MjUsImV4cCI6MjAyOTE1NjcyNX0.MRddKpZ3_57Vddk2Gk4RZ9msKzNPGtmkSpqmXH_BuOY";
			var options = new SupabaseOptions
			{
				AutoRefreshToken = true,
				AutoConnectRealtime = true,
				// SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
			};

			// Note the creation as a singleton.
			builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));




			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<ICartRepository, CartRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<DataContext>(options =>
				options.UseNpgsql("User Id=postgres.pepiwahqzfqojffolhaq;Password=helloworld@siu2003k14;Server=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;"));

			var app = builder.Build();


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