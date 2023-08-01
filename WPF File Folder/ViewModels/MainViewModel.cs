using System;
using System.ComponentModel;
using System.IO;
using WPF_File_Folder.Models.Classes;
using WPF_File_Folder.Models.Interfaces;

namespace WPF_File_Folder.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {

        private ISystemItem _item;
        public ISystemItem DefaultFolder { get => _item; set { _item = value; OnPropertyChanged(nameof(DefaultFolder)); } }

        public MainViewModel(ISystemItem systemItem) { 
            _item = systemItem;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName) {
            PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
