using AvaloniaTemplate.ApiContracts.RecipeContracts;
using ErrorOr;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AvaloniaTemplate.ApiClients.Recipe;

public class RecipeApiClient : IRecipeApiClient
{
    private readonly HttpClient _client;
    private readonly string _baseUri;
    private readonly string _apiUrl;

    public RecipeApiClient(HttpClient client, string baseUri, string apiUrl)
    {
        _client = client;
        _baseUri = baseUri;
        _apiUrl = apiUrl;
    }

    public async Task<ErrorOr<ICollection<FeaturedRecipe>>> GetFeatured()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{_baseUri}{_apiUrl}featured"),
        };
        try
        {
            var response = await _client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<RecipeGetFeaturedOutput>(body);

            if (list == null)
            {
                return Error.Failure("Not found");
            }
            return list.Recipes;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
