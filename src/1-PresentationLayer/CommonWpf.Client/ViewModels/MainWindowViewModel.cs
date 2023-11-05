using CommonWpf.Configuration;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CommonWpf.Client.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    private readonly ILogger<MainWindowViewModel> _logger;
    private readonly IOptions<ConnectionOption> _option;

    [ObservableProperty]
    private string? _name;

    public MainWindowViewModel(ILogger<MainWindowViewModel> logger, IOptions<ConnectionOption> option)
    {
        _logger = logger;
        _option = option;
        Name = "123";
        _logger.LogInformation("main window{0}", "1235456");
        _logger.LogInformation("connectionstring is {@Connection}", _option.Value);
    }
}
