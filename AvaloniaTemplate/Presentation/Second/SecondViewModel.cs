using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaTemplate.Presentation.Second;

public partial class SecondViewModel : ViewModelBase
{
    private readonly HistoryRouter<ViewModelBase> _router;

    public SecondViewModel(HistoryRouter<ViewModelBase> router)
    {
        _router = router;
    }

    [RelayCommand]
    public void GoBack()
    {
        _router.Back();
    }
}
