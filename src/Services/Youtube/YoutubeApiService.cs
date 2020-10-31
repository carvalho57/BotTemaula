using System.Collections.Generic;
using System.Threading.Tasks;
using temAulaBotTelegram.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using static Google.Apis.YouTube.v3.SearchResource.ListRequest;

namespace temAulaBotTelegram.Services
{
    public class YoutubeApiService
    {
        private readonly YouTubeService _youtubeApi;
        private readonly string YoutubeChannelId;
        public YoutubeApiService(YouTubeService youtubeService, string youtubeChannelId)
        {
            _youtubeApi = youtubeService;            
            YoutubeChannelId = youtubeChannelId;
        }

        public async Task<SearchListResponse> Search(string channelId, EventTypeEnum eventType, OrderEnum order, int maxResults = 1, string part = "id,snippet", string type = "video")
        {
            var searchListRequest = _youtubeApi.Search.List(part);
            searchListRequest.ChannelId = channelId;
            searchListRequest.EventType = eventType;
            searchListRequest.Type = type;
            searchListRequest.MaxResults = maxResults;
            searchListRequest.Order = order;

            return await searchListRequest.ExecuteAsync();
        }

        public async Task<VideoListResponse> GetVideoInfo(string id, string part)
        {
            var searchVideoRequest = _youtubeApi.Videos.List(part);
            searchVideoRequest.Id = id;

            var searchVideoResponse = await searchVideoRequest.ExecuteAsync();
            return searchVideoResponse;
        }

        public async Task<List<LiveModel>> GetUpcommingLives(OrderEnum order, int maxResults = 1)
        {
            var searchListResponse = await this.Search(this.YoutubeChannelId, EventTypeEnum.Upcoming, order,maxResults);
            var lives = new List<LiveModel>();
            foreach (var searchResult in searchListResponse.Items)
            {
                lives.Add(searchResult.ToLiveModel());
            }
            return lives;
        }
        
        public async Task<LiveModel> GetLive()
        {
            var response = await Search(this.YoutubeChannelId, EventTypeEnum.Live, OrderEnum.Date);
            return response.Items.Count != 0 
                ? response.Items[0].ToLiveModel() 
                : null;
        }

        public async Task<VideoListResponse> GetInfoLive(string videoId)
        {
            // Retorna informações de data sobre lives agendadas
            var videoInfo = await GetVideoInfo(videoId, "liveStreamingDetails");
            return videoInfo;
        }
    }
}