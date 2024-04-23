using Avalonia.SimpleRouter;
using AvaloniaTemplate.ApiClients.Recipe;
using AvaloniaTemplate.ApiContracts.RecipeContracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Linq;

namespace AvaloniaTemplate.Presentation.Second;

public partial class SecondViewModel : ViewModelBase
{
    private readonly HistoryRouter<ViewModelBase> _router;
    private readonly IRecipeApiClient _recipeApiClient;

    [ObservableProperty]
    private RecipeNewModel _recipe;

    public SecondViewModel(HistoryRouter<ViewModelBase> router, IRecipeApiClient recipeApiClient)
    {
        _router = router;
        _recipeApiClient = recipeApiClient;
        GetData();
    }



    [RelayCommand]
    public void GoBack()
    {
        _router.Back();
    }

    private async void GetData()
    {
        var result = await _recipeApiClient.GetFeatured();
        if (result.IsError || result.Value is null || result.Value.Count == 0)
        {
            throw new NotImplementedException();
        }

        Recipe = result.Value.First().Recipe;
    }
}
