﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MVVM;
using WPFMediaKit.DirectShow.Controls;


namespace HireHomeEntertainment.ViewModel
{
    class MediaPlayerViewModel : ViewModelBase
    {  

       #region Public Variables
        public MediaUriElement MediaEL { set; get; } 
       // public MediaElement MediaEL { set; get; }
       // public MediaState LoadedBehavior { set; get; }
        public bool CanCommandExecute { set; get; }   
          
       #endregion

       #region Private Variables
        
       #endregion

       #region Constructor

       public MediaPlayerViewModel(string MediaURI)
       {           
           RegisterCommands();           

          // MediaEL = new MediaElement();
           MediaEL = new MediaUriElement();
           MediaEL.VideoRenderer = WPFMediaKit.DirectShow.MediaPlayers.VideoRendererType.VideoMixingRenderer9;
           if (MediaURI != "")
           {
               //Only add "\\VIDEO_TS\\VTS_01_1.VOB" if a vob file
             //  MediaURI = MediaURI + "\\VIDEO_TS\\VTS_01_0.VOB";
               Uri MediaSource = new Uri(MediaURI);                
               MediaEL.Source = MediaSource;
           }
           MediaEL.LoadedBehavior = WPFMediaKit.DirectShow.MediaPlayers.MediaState.Manual;
        //   MediaEL.LoadedBehavior = MediaState.Manual;
       }

       #endregion

       #region commands

        public static RelayCommand PlayCommand { get; set; }
        public static RelayCommand StopCommand { get; set; }
        public static RelayCommand PauseCommand { get; set; }
        public static RelayCommand ResumeCommand { get; set; }
        public static RelayCommand WorkspaceCloseCommand { get; set; }  

        #endregion        

        private void RegisterCommands()
        {
            PlayCommand = new RelayCommand(param => ExecutePlay());
            StopCommand = new RelayCommand(param => ExecuteStop());
            PauseCommand = new RelayCommand(param => ExecutePause());
            ResumeCommand = new RelayCommand(param => ExecuteResume()); 
        }

        #region Media Controls

        private void ExecutePlay()
        {
            MediaEL.Play();
        }
        private void ExecuteStop()
        {
            MediaEL.Stop();
        }
        private void ExecutePause()
        {
            MediaEL.Pause();
        }
        private void ExecuteResume()
        {
            
        }

        #endregion
                
    }
}
