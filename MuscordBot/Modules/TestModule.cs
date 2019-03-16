using Discord.Commands;
using MuscordBot.Data;
using MuscordBot.Data.Connection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MuscordBot.Modules {
    [Name("Commands for testing purposes")]
    public class TestModule: ModuleBase<SocketCommandContext> {

        private HttpClient _client;

        public TestModule() {
            _client = ConnectionJson.APIClient;
        }

        //kleine letters voor commando naam
        [Command("ping")]
        [Alias("p")]//alias voor het commando
        public async Task respondPing() {
            await Context.Channel.SendMessageAsync("pong");
        }
    }
}
