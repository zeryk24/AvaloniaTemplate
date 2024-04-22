using Avalonia.SimpleRouter;
using AvaloniaTemplate.Presentation;
using AvaloniaTemplate.Presentation.Home;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaTemplate.Presentation.Main;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _content = default!;

    public MainViewModel(HistoryRouter<ViewModelBase> router)
    {
        // register route changed event to set content to viewModel, whenever 
        // a route changes
        router.CurrentViewModelChanged += viewModel => Content = viewModel;
 
        router.GoTo<HomeViewModel>();
    }
}
