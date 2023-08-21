using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace CommonWpf.Client.ViewModels
{
    public sealed partial class MainWindowViewModel : ObservableObject
    {
        private readonly ILogger<MainWindowViewModel> _logger;

        [ObservableProperty]
        private string? _name;

        public MainWindowViewModel(ILogger<MainWindowViewModel> logger)
        {
            _logger = logger;
            Name = "123";
            _logger.LogInformation("main window");
        }
    }
}
