using Hangfire;
using Telegram.Bot;
using Hangfire.MemoryStorage;
using temAulaBotTelegram.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<TelegramBotClient>(telegram);
            services.AddScoped<IMemberService, MemberService>();    
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IDispatcherService, DispatcherService>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });

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
