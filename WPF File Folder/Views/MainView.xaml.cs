using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using WPF_File_Folder.Models.Classes;
using WPF_File_Folder.Models.Interfaces;
using WPF_File_Folder.ViewModels;

namespace WPF_File_Folder.Views {
    public partial class MainView : Window, INotifyPropertyChanged {
        private ISystemItem _item;
        public ISystemItem DefaultFolder { get => _item; set { _item = value; OnPropertyChanged(); } }
        public MainView() {
            InitializeComponent();
            DataContext = this;
            _item = new Folder($"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))}", $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))}");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null) { 
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (FolderNames.SelectedItem == null)
                return;

            if ((FolderNames.SelectedItem as Folder) == null) {
                DefaultFolder = (FolderNames.SelectedItem as WPF_File_Folder.Models.Classes.File)!;
            } 
            else DefaultFolder = (FolderNames.SelectedItem as Folder)!;
            FolderNames.SelectedItem = null;
        }
    }
}
