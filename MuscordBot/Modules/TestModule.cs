using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuscordBot.Modules {
    [Name("Commands for testing purposes")]
    public class TestModule: ModuleBase<SocketCommandContext> {

        //kleine letters voor commando naam
        [Command("ping")]
        [Alias("p")]//alias voor het commando
        public async Task respondPing() {
            await Context.Channel.SendMessageAsync("pong");
        }
    }
}
