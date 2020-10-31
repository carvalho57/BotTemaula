using Hangfire;
using Telegram.Bot;
using Hangfire.MemoryStorage;
using temAulaBotTelegram.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var telegram = new TelegramBotClient(Configuration.GetSection("BotConfiguration").GetSection("BotToken").Value);
            telegram.SetWebhookAsync(Configuration.GetSection("BotConfiguration").GetSection("UrlWebHook").Value);
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Configuration.GetSection("BotConfiguration").GetSection("TokenYoutubeApi").Value            
            });

            var youtubeApiService  = new YoutubeApiService(youtubeService, Configuration.GetSection("BotConfiguration").GetSection("YoutubeChannelId").Value);
            services.AddSingleton<TelegramBotClient>(telegram);
            services.AddSingleton<YouTubeService>(youtubeService);            
            services.AddSingleton<YoutubeApiService>(youtubeApiService);
            services.AddSingleton<RegisteredServices, RegisteredServices>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IDispatcherService, DispatcherService>();


            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireServer();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
