﻿using Avalonia.SimpleRouter;
using AvaloniaTemplate.Presentation.Second;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaTemplate.Presentation.Home;

public partial class HomeViewModel : ViewModelBase
{
    private readonly HistoryRouter<ViewModelBase> _router;

    public HomeViewModel(HistoryRouter<ViewModelBase> router)
    {
        _router = router;
    }

    [RelayCommand]
    public void GoToSecond()
    {
        _router.GoTo<SecondViewModel>();
    }
}
