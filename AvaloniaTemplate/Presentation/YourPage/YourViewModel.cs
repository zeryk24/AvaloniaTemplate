using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaTemplate.Presentation.YourPage;

public partial class YourViewModel : ViewModelBase
{
    private readonly HistoryRouter<ViewModelBase> _router;

    [ObservableProperty]
    private string _title = "YourPage";

    public YourViewModel(HistoryRouter<ViewModelBase> router)
    {
        _router = router;
        GetData();
    }

    [RelayCommand]
    public void GoBack()
    {
        _router.Back();
    }

    private async void GetData()
    {
        //TODO: call api client and handle error
    }
}
