using System;

namespace ProxyPattern
{
    public class RealImage:IImage
    {
        public RealImage(string filePath)
        {
            this.FilePath = filePath;
        }
        public string FilePath { get; set; }

        public void Display() => Console.WriteLine($"File Path is {this.FilePath}");
    }
}
