using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PSAvalonia;
using System.Configuration;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace PSAvaloniaDebug
{
    internal class PSAvaloniaDebug
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello Avalonia!");
            //var Xaml0 = @"
            //<Window xmlns='https://github.com/avaloniaui'>
            //    <TextBlock>
            //        Hello World!
            //    </TextBlock>
            //</Window>";
            //var win = AvaloniaBootstrapper.Load(Xaml.ToString());
            //var path = AppContext.BaseDirectory + @"\PSAvaloniaDebug.xaml";
            //Uri pathUri = new Uri(path, UriKind.Absolute).ToString();
            //var win = AvaloniaBootstrapper.Load(pathUri);
            var Xaml0 = @"
            <Window xmlns='https://github.com/avaloniaui'>
                <TextBlock>
                    Hello World!
                </TextBlock>
            </Window>";

            var Xaml1 = @"
            <Window xmlns='https://github.com/avaloniaui'
                xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                xmlns:d='http://schemas.microsoft.com/expression/blend/2008'
                xmlns:mc='http://schemas.openxmlformats.org/markup-compatibility/2006'
                mc:Ignorable='d' d:DesignWidth='800' d:DesignHeight='450'
                x:Class='PSAvalonia.MainWindow'
                Title='PSAvalonia'>
                   <StackPanel>
                   <Button Width='160' Name='button'>My Button</Button>
                       <TextBox HorizontalAlignment='Left' Margin='12,12,0,0' Name='txtDemo' VerticalAlignment='Top' Width='500' Height='25' />
                   </StackPanel>
            </Window>";

            var Xaml2 = @"
        <Window xmlns='https://github.com/avaloniaui'
                xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                xmlns:d='http://schemas.microsoft.com/expression/blend/2008'
                xmlns:mc='http://schemas.openxmlformats.org/markup-compatibility/2006'
                mc:Ignorable='d' d:DesignWidth='400' d:DesignHeight='400'
                Title='PSAvalonia'>
                <Window.Styles>
                    <StyleInclude Source='avares://Avalonia.Themes.Default/DefaultTheme.xaml'/>
                    <StyleInclude Source='avares://Avalonia.Themes.Default/Accents/BaseLight.xaml'/>
                </Window.Styles>
                <StackPanel>
                    <Grid ColumnDefinitions='100,200,100,*'>
                        <TextBlock Name='lbl'  Grid.Column='0' Margin='5'>Enter text</TextBlock>
                        <TextBox   Name='txt'  Grid.Column='1' Margin='5'></TextBox>
                        <Button    Name='btn'   Grid.Column='2' Margin='5'>Submit</Button>
                        <TextBlock Name='rslt' Grid.Column='3' Margin='5'></TextBlock>
                    </Grid>
                </StackPanel>
            </Window>";
            var win = AvaloniaBootstrapper.Load(Xaml2);
            //var rslt = win.FindControl<IControl>("rslt");
            //Button btn = win.FindControl<IControl>("btn") as Button;
            //btn.Click += OnButtonClick;
            AvaloniaBootstrapper.Start(win);
        }
    }
}
