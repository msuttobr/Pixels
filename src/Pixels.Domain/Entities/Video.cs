namespace Pixels.Domain.Entities
{

    public class Video
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int Duration { get; set; }
        public VideoUser User { get; set; } = new();
        public List<VideoFile> VideoFiles { get; set; } = new();
        public List<VideoPicture> VideoPictures { get; set; } = new();
        public Video(int id, int width, int height, string url, string image, int duration, VideoUser user, List<VideoFile> videoFiles, List<VideoPicture> videoPictures)
        {
            Id = id;
            Width = width;
            Height = height;
            Url = url;
            Image = image;
            Duration = duration;
            User = user;
            VideoFiles = videoFiles;
            VideoPictures = videoPictures;
        }
        public class VideoUser
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
        public class VideoFile
        {
            public string Id { get; set; }
            public string Quality { get; set; }
            public string FileType { get; set; }
            public decimal Fps { get; set; }
            public string Link { get; set; }
        }
        public class VideoPicture
        {
            public string Id { get; set; }
            public int Nr { get; set; }
            public string Picture { get; set; }
        }
    }
}