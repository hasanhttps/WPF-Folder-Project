using System;
using WPF_File_Folder.Models.Interfaces;


namespace WPF_File_Folder.Models.Classes {

    public class File : ISystemItem {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public double Size { get; }


        public File(string? name, double size, string? path = "") {
            Name = name;
            Path = path;
            Size = size;
        }
    }
}
