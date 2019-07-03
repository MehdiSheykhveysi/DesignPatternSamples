namespace ProxyPattern
{
    public class ImageProxy : IImage
    {
        public ImageProxy(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; set; }

        public RealImage RealImage { get; set; }

        public void Display()
        {
            if (RealImage == null)
                RealImage = new RealImage(FilePath);

            RealImage.Display();
        }
    }
}
