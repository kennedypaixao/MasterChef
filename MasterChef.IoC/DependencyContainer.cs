using MasterChef.Application.Repository;
using MasterChef.Application.Service;
using MasterChef.Infrastructure.Repository.Account;
using MasterChef.Infrastructure.Repository.Recipe;
using Microsoft.Extensions.DependencyInjection;

namespace MasterChef.IoC
{
	public class DependencyContainer
	{
        public static void RegisterServices(IServiceCollection services)
        {
			// Repositories
			var connection = @"Server=(localdb)\mssqllocaldb;Database=MasterChef;Trusted_Connection=True;ConnectRetryCount=0";
			services.AddSingleton<IUserRepository>(new UserRepository(connection));
			services.AddSingleton<IIngredientRepository>(new IngredientRepository(connection));
			services.AddSingleton<IRecipeRepository>(new RecipeRepository(connection));

			// Services
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IIngredientService, IngredientService>();
			services.AddScoped<IRecipeService, RecipeService>();
		}
    }
}
