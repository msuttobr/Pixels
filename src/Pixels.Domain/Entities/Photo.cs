namespace Pixels.Domain.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Alt { get; set; }
        public string Photographer { get; set; }
        public string PhotographerUrl { get; set; }
        public PhotoSrc Src { get; set; }

        public Photo(int id, int width, int height, string url, string alt, string photographer, string photographerUrl, PhotoSrc src)
        {
            Id = id;
            Width = width;
            Height = height;
            Url = url;
            Alt = alt;
            Photographer = photographer;
            PhotographerUrl = photographerUrl;
            Src = src;
        }
        public class PhotoSrc
        {
            public string Original { get; set; }
        }
    }
}