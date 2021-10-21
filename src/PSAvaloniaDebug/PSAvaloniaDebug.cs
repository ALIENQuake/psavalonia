using System;
using PSAvalonia;

namespace PSAvaloniaDebug
{
    internal class PSAvaloniaDebug
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var Xaml = @"<Window xmlns=""https://github.com/avaloniaui""
            //     xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
            //     xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
            //     xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
            //     mc:Ignorable=""d"" d:DesignWidth=""800"" d:DesignHeight=""450""
            //     x:Class=""PSAvalonia.MainWindow""
            //     Title=""PSAvalonia"">
            //        <StackPanel>
            //     <Button Width=""160"" Name=""button"">My Button</Button>
            //             <TextBox HorizontalAlignment=""Left"" Margin=""12,12,0,0"" Name=""txtDemo"" VerticalAlignment=""Top"" Width=""500"" Height=""25"" />
            //         </StackPanel>
            //</Window>";
            //var window = AvaloniaBootstrapper.Load(Xaml.ToString());
            //var Xaml = new Uri(args[0], UriKind.Absolute);
            var path = AppContext.BaseDirectory + @"\PSAvaloniaDebug.xaml";
            var Xaml = new Uri(path, UriKind.Absolute);
            var window = AvaloniaBootstrapper.Load(Xaml.ToString());
        }
    }
}
