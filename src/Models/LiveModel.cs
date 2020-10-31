namespace temAulaBotTelegram.Models {
    public class LiveModel {
        public LiveModel(string videoId, string channelId, string channelTitle, string description, string defaultThumbnail, string highThumbnail, string mediumThumbnail)
        {
            VideoId = videoId;
            ChannelId = channelId;
            ChannelTitle = channelTitle;
            Description = description;            
            DefaultThumbnail = defaultThumbnail;
            HighThumbnail = highThumbnail;
            MediumThumbnail = mediumThumbnail;
            Url =$"https://www.youtube.com/watch?v={VideoId}";   
        }

        public string VideoId { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string Description {get;set;}
        
        public string DefaultThumbnail {get;set;}
        public string HighThumbnail {get;set;}
        public string MediumThumbnail {get;set;}
        public string Url {get;}
    }
}