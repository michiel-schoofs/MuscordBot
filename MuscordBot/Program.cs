using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MuscordBot.Data;
using MuscordBot.Data.Connection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MuscordBot {
    class Program {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        private readonly string prefix = "!";
        private JSONConnection _connection;

        static void Main(string[] args) {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync() {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            ConnectionJson.InitializeClient();

            DependencyInjection();

            await InstallCommands();

            Console.WriteLine("Logging in...");
            string botKey = "NTU2NDAyNzc3NTg5NTQ3MDA4.D25O0Q.GQaVOA5qo_lb42m04LMUyrplLVQ";
            await _client.LoginAsync(TokenType.Bot,botKey);
            await _client.StartAsync();

            Console.WriteLine("Ready");

            await Task.Delay(-1);
        }

        private void DependencyInjection() {
            Console.WriteLine("Injecting to database");

            _services = new ServiceCollection()
                            .AddSingleton(_client)
                            .BuildServiceProvider();
        }

        public async Task InstallCommands() {
            _client.MessageReceived += HandleCommands;

            Console.WriteLine("Initializing commands...");
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }


        private async Task HandleCommands(SocketMessage arg) {
            
            if (arg == null || arg.Author.IsBot)
                return;

            SocketUserMessage msg = arg as SocketUserMessage;
            int argPos = 0;

            if (msg.HasStringPrefix(prefix, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos)) {
                var context = new SocketCommandContext(_client, msg);
                IResult result = await _commands.ExecuteAsync(context, argPos, _services);
            }

        }

    }
}
