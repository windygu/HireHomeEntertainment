﻿using System;
using System.Windows;
using System.Windows.Input;
using MVVM;
using GalaSoft.MvvmLight.Messaging;
using HireHomeEntertainment.View;
using HireHomeEntertainment.Singletons;

namespace HireHomeEntertainment.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {        
        public MainWindowViewModel()
        {
            //Registers to listen for any keypress in the MainWindow
            Messenger.Default.Register<KeyEventArgs>(this, MainWindow_KeyDown);   
            //Load Default Page   
            PageNavigation.Instance.NavigatePage("p1");          
        }
        
        private void MainWindow_KeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
                {
                    PageNavigation.Instance.NavigatePage("p1");
                }
                if (e.Key == Key.D2 || e.Key == Key.NumPad2)
                {
                    PageNavigation.Instance.NavigatePage("p2");
                }
        }
    }
}
