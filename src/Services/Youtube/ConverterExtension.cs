using Google.Apis.YouTube.v3.Data;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services {
    public static class ConverterToModelExtension {
        public static LiveModel ToLiveModel(this SearchResult searchResult) {
            return new LiveModel(
                        searchResult.Id.VideoId,
                        searchResult.Snippet.ChannelId,
                        searchResult.Snippet.ChannelTitle,
                        searchResult.Snippet.Description,
                        searchResult.Snippet.Thumbnails.Default__.Url,
                        searchResult.Snippet.Thumbnails.Medium.Url,
                        searchResult.Snippet.Thumbnails.High.Url
                        );
        }
    }
}