using System;

namespace WPF_File_Folder.Models.Interfaces;
public interface ISystemItem {
    string? Name { get; set; }
    string? Path { get; set; }
    double Size { get; }
}
