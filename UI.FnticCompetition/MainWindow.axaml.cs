using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using BL.FnticCompetition;
using BL.FnticCompetition.Services;
using UI.FnticCompetition.ViewModel;

namespace UI.FnticCompetition;

public partial  class MainWindow : Window
{




    public MainWindow()
    {
        InitializeComponent();
    }
    
  

    public MainWindow(MainViewModel viewModel)
    {
        
        // Prevent the previewer's DataContext from being set when the application is run.
        if (Design.IsDesignMode)
        {
            // This can be before or after InitializeComponent.
            Design.SetDataContext(this, new MainViewModel(null,null,null,null) );
        }
        InitializeComponent();
        this.DataContext = viewModel; 
    
    }

    private  async void  BtnStartSession_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            
            HotspotManager hotspotManager = new HotspotManager();
            hotspotManager.StartHotspot(Txtssid.Text,TxtPwd.Text);
            var connectedDevices = hotspotManager.GetConnectedDevices();


            while (true)
            {
                TxtBlock.Text = $"Hotspot is running {Txtssid.Text} ";
                TxtBlock.Foreground = Brushes.SeaGreen;
                TxtBlock.Text += string.Join(" ", connectedDevices);
                await Task.Delay(1000);
            }
           
               

           
           


        }
        catch (Exception exception)
        {
            TxtBlock.Text = exception.Message;
            TxtBlock.Foreground = Brushes.Red;
            Console.WriteLine(exception);
            throw;
        }
     
        
    }
}