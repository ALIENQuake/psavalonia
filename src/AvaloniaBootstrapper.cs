using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using Avalonia.ReactiveUI;
using System.Linq;
using System.Threading;

namespace PSAvalonia
{
    public static class AvaloniaBootstrapper
    {
        public static App App;
        private static CancellationTokenSource _source;
        private static List<Window> _usedWindows = new List<Window>();

        private static AppBuilder BuildAvaloniaApp()
        {
            var lifetime = new ClassicDesktopStyleApplicationLifetime();
            lifetime.ShutdownMode = ShutdownMode.OnMainWindowClose;
            return AppBuilder.Configure<App>().UseReactiveUI().UsePlatformDetect().SetupWithLifetime(lifetime);
        }

        static AvaloniaBootstrapper()
        {
            new CustomAssemblyLoadContext().LoadNativeLibraries();
            new CustomAssemblyLoadContext().LoadLibs();
            App = (App)BuildAvaloniaApp().Instance;
        }

        public static Window Load(string xaml)
        {
            var loader = new AvaloniaXamlLoader();
            return (Window)loader.Load(xaml);
        }

        public static void Start(Window window)
        {
            if (_usedWindows.Any(m => ReferenceEquals(m, window)))
            {
                throw new System.Exception("Cannot show window again. Use ConvertTo-AvaloniaWindow to create a new window.");
            }

            _usedWindows.Add(window);

            _source = new CancellationTokenSource();

            window.Show();
            window.Closing += Window_Closing;

            App.Run(_source.Token);
        }

        private static void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _source.Cancel();
        }
    }

}
