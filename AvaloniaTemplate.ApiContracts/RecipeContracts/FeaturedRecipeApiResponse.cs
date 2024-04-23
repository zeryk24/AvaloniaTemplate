namespace AvaloniaTemplate.ApiContracts.RecipeContracts;

public class RecipeGetFeaturedOutput
{
    public List<FeaturedRecipe> Recipes { get; init; }
}

public record FeaturedRecipe
{
    public string Headline { get; init; }
    public RecipeNewModel Recipe { get; init; }
}

public record RecipeNewModel
{
    public Guid Id { get; init; }
    public object Share { get; init; }
    public Guid Owner { get; init; }
    public string AuthorName { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public object Method { get; init; }
    public object GroundSize { get; init; }
    public DateTime Created { get; init; }
    public object State { get; init; }
    public int WaterGrams { get; init; }
    public TimeSpan Time { get; init; }
    public int GroundsGrams { get; init; }
    public float Rating { get; init; }
    public List<object> Tags { get; init; }
    public DateTime LastEdited { get; init; }
    public List<object> Steps { get; init; }
    public List<object> Reviews { get; init; }
}