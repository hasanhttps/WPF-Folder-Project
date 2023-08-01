using System;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using WPF_File_Folder.Models.Interfaces;


namespace WPF_File_Folder.Models.Classes {
    public class Folder : ISystemItem {

        ObservableCollection<ISystemItem> _systemItems;

        public ObservableCollection<ISystemItem> systemItems { get { return _systemItems; } set { _systemItems = value; } }

        public Folder(string? name, string? path) {
            Name = name;
            Path = path;
            _systemItems = new();
            setFolder();
        }

        public string? Name { get; set; }
        public string? Path { get; set; }
        public double Size {
            get {
                Console.WriteLine(Name);
                return _systemItems.Sum(item => item.Size);
            }
        }

        public void setFolder() { 
            DirectoryInfo directoryInfo = new DirectoryInfo(Path!);
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in directoryInfos) {
                _systemItems.Add(new Folder(directory.Name, directory.FullName));
            }

            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (FileInfo file in fileInfos) {
                _systemItems.Add(new File(file.Name, file.Length, file.FullName));
            }
        }
        public void Add(ISystemItem item) {
            item.Path = $@"{Path}\{item.Name}";
            _systemItems.Add(item);
        }

        public void Delete(ISystemItem item)
        => _systemItems.Remove(item);

        public ObservableCollection<ISystemItem> GetSystemItems()
            => _systemItems;

    }
}
