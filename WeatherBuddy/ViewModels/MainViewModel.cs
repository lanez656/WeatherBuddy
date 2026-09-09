using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherBuddy.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to WeatherBuddy!";
}
