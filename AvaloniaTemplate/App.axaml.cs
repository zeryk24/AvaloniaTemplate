using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.SimpleRouter;
using AvaloniaTemplate.ApiClients.Recipe;
using AvaloniaTemplate.ApiClients.Yours;
using AvaloniaTemplate.Presentation;
using AvaloniaTemplate.Presentation.Home;
using AvaloniaTemplate.Presentation.Main;
using AvaloniaTemplate.Presentation.Second;
using AvaloniaTemplate.Presentation.YourPage;
using AvaloniaTemplate.Views;
using HotAvalonia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;

namespace AvaloniaTemplate;

public partial class App : Application
{
    public override void Initialize()
    {
        //COMMENT THIS OUT ON OTHER PLATFORM THAN DESKTOP
        this.EnableHotReload();
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        IServiceProvider services = ConfigureServices();

        var mainViewModel = services.GetRequiredService<MainViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton(s => new HistoryRouter<ViewModelBase>(t => (ViewModelBase)s.GetRequiredService(t)));

        using var stream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("AvaloniaTemplate.Configurations.appsettings.json");

        var configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();

        var recipeBaseUri = configuration["RecipeApiSettings:RecipeApiBaseUri"];
        var recipeApiUrl = configuration["RecipeApiSettings:RecipeApiUrl"];

        var recipeClient = new HttpClient()
        {
            BaseAddress = new Uri(recipeBaseUri)
        };

        var yoursBaseUri = configuration["YoursApiSettings:YoursApiBaseUri"];
        var yoursApiUrl = configuration["YoursApiSettings:YoursApiUrl"];

        var yoursClient = new HttpClient()
        {
            BaseAddress = new Uri(yoursBaseUri)
        };

        services.AddTransient<IRecipeApiClient>((provider) => new RecipeApiClient(recipeClient, recipeBaseUri, recipeApiUrl));
        services.AddTransient<IYoursApiClient>((provider) => new YoursApiClient(yoursClient, yoursBaseUri, yoursApiUrl));

        services.AddTransient<MainViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SecondViewModel>();
        services.AddTransient<YourViewModel>();

        return services.BuildServiceProvider();
    }
}
