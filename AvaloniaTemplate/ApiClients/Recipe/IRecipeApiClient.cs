using AvaloniaTemplate.ApiContracts.RecipeContracts;
using ErrorOr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaTemplate.ApiClients.Recipe;

public interface IRecipeApiClient
{
    public Task<ErrorOr<ICollection<FeaturedRecipe>>> GetFeatured();
}
