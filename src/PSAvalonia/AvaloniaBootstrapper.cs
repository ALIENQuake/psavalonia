using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PSAvalonia
{
    public static class AvaloniaBootstrapper
    {
        public static App App;
        //public static Window MainWindow;
        private static CancellationTokenSource _source;
        private static List<Window> _usedWindows = new List<Window>();

        private static AppBuilder BuildAvaloniaApp()
        {
            var lifetime = new ClassicDesktopStyleApplicationLifetime();
            lifetime.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //lifetime.MainWindow = MainWindow;
            AppBuilder app = AppBuilder.Configure<App>().UseReactiveUI().UsePlatformDetect().SetupWithLifetime(lifetime);
            return app;
        }

        static AvaloniaBootstrapper()
        {
            new CustomAssemblyLoadContext().LoadNativeLibraries();
            new CustomAssemblyLoadContext().LoadLibs();
            App = (App)BuildAvaloniaApp().Instance;
        }

        public static Window Load(string xaml)
        {
            var win = (Window)AvaloniaRuntimeXamlLoader.Load(xaml);
            return win;
        }
        
        //public static Window Load(string xaml)
        //{
        //    System.Uri uri = new System.Uri(xaml, System.UriKind.Absolute);
        //    var win = (Window)AvaloniaXamlLoader.Load(uri);
        //    return win;
        //}

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
            //App.OnFrameworkInitializationCompleted();

            App.Run(_source.Token);
        }

        private static void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _source.Cancel();
        }
    }
}
