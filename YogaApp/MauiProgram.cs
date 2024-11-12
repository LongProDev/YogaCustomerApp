using Microsoft.Extensions.DependencyInjection;
using Refit;
using YogaApp.Services;
using YogaApp.ViewModels;
using YogaApp.Views;

namespace YogaApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register services
        builder.Services.AddRefitClient<IYogaApiService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://yogaclassmanagement.onrender.com"));

        // Register ViewModels
        builder.Services.AddTransient<ClassDetailsViewModel>();
        builder.Services.AddTransient<ClassListViewModel>();

        // Register Pages
        builder.Services.AddTransient<ClassDetailsPage>();
        builder.Services.AddTransient<ClassListPage>();

        return builder.Build();
    }
}