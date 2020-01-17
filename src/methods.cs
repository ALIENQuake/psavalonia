
using System.Management.Automation;
using Avalonia.Controls;
using System.Collections;
using System;
using System.Collections.Generic;

namespace PSAvalonia
{
    [Cmdlet(VerbsData.ConvertTo, "AvaloniaWindow")]
    public class ConvertToAvaloniaWindow : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Xaml { get; set; }

        protected override void ProcessRecord()
        {
            var dataGridType = typeof(DataGrid); // HACK
            var window = AvaloniaBootstrapper.Load(Xaml);
            WriteObject(window);
        }
    }

    [Cmdlet(VerbsCommon.Find, "AvaloniaControl")]
    public class FindAvaloniaControl : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public Window Window { get; set; }
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(Window.FindControl<IControl>(Name));
        }
    }

    [Cmdlet(VerbsCommon.Show, "AvaloniaWindow")]
    public class ShowAvaloniaWindow : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public Window Window { get; set; }

        protected override void ProcessRecord()
        {
            AvaloniaBootstrapper.Start(Window);
        }
    }

    public class GUI
    {

        // call [GUI]::CreateWindow([string]$string);
        // will convert xaml string into a Avalonia window.
        public static Window CreateWindow(string Xaml)
        {
            return AvaloniaBootstrapper.Load(Xaml);
            //returns new [Avalonia.Controls.Window] object
        }

        // call [GUI]::FindControl([Avalonia.Controls.Window]$Window);
        // this will search the window specified
        public static IControl FindControl(Window window, string name)
        {
            return window.FindControl<IControl>(name);
            //returns new [Avalonia.Controls.IControl] object. 'IControl' is a type- will not be final object.
        }

        // this will open a window you have created.
        // call [GUI]::ShowWindow($Main_Window)
        public static void ShowWindow(Window window)
        {
            AvaloniaBootstrapper.Start(window);
        }
    }

    // [Cmdlet(VerbsData.Out, "GridViewCore")]
    // public class OutGridViewCore : PSCmdlet
    // {
    //     private List<PSObject> _objects = new List<PSObject>();

    //     [Parameter(ValueFromPipeline = true, Mandatory = true)]
    //     public PSObject InputObject { get; set; }

    //     protected override void ProcessRecord()
    //     {
    //         _objects.Add(InputObject);
    //     }

    //     protected override void EndProcessing()
    //     {
    //         var window = new OutGridView.OutGridViewWindow(_objects);
    //         AvaloniaBootstrapper.Start(window);
    //     }
    // }
}