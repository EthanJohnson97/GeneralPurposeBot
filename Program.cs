﻿using Discord.Commands;
using Discord.WebSocket;
using GeneralPurposeBot.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GeneralPurposeBot
{
    public static class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appsettings.json", true))
                .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("config.json", true)) // old config file name
                .ConfigureAppConfiguration(cfg => cfg.AddEnvironmentVariables())
                .ConfigureAppConfiguration(cfg => cfg.AddCommandLine(args))
                .ConfigureLogging((host, logger) => logger.AddConfiguration(host.Configuration.GetSection("Logging")))
                .ConfigureLogging(logger => logger.AddConsole())
                .ConfigureServices(ConfigureServices)
                .ConfigureServices(services => services.AddHostedService<BotHostedService>());

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<DiscordSocketClient>();
            services.AddSingleton<CommandService>();
            services.AddSingleton<CommandHandler>();
            services.AddSingleton<CuteDetection>();
            services.AddSingleton<DiscordLogWrapper>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<ServerPropertiesService>();
            services.AddSingleton<TempVcService>();

            services.AddDbContext<BotDbContext>(options =>
                options.UseMySql(host.Configuration.GetConnectionString("mysql")), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
        }
    }
}
