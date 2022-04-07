using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media.Imaging;
using Avalonia;
using Avalonia.Platform;
using System.Reflection;
using System.IO;

namespace lab8visual.Models
{
    public class Task : INotifyPropertyChanged
    {
        string name;
        string description;
        Bitmap image;
        public event PropertyChangedEventHandler PropertyChanged;
        public Task(string _status, string _name = "Task header", string _description = "",
            string _imagePath = @"Assets\avalonia-logo.ico")
        {
            name = _name;
            description = _description;
            ImagePath = _imagePath;
            Status = _status;
            if (_imagePath == @"Assets\avalonia-logo.ico")
            {
                string directoryPath = Directory.GetCurrentDirectory();
                directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
                _imagePath = directoryPath + _imagePath;
            }
            image = new Bitmap(_imagePath);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Status { get; set; }
        public string ImagePath { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        public Bitmap Image
        {
            get => image;
            set
            {
                image = value;
                NotifyPropertyChanged();
            }
        }
    }
}
