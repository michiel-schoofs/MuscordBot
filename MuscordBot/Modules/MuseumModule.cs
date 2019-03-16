using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MuscordBot.Data.Parsers;
using Newtonsoft.Json;
using MuscordBot.Domain;
using MuscordBot.EmbedBuilders;
using Discord;

namespace MuscordBot.Data.Connection {
    [Name("Museum commands")]
    public class MuseumModule : ModuleBase<SocketCommandContext> {
        private HttpClient _client;
        private Museum_Accesability_Parser _map;
        private MuseumListBuilder _mlb;

        public MuseumModule(Museum_Accesability_Parser map, MuseumListBuilder mlb) {
            _client = ConnectionJson.APIClient;
            _map = map;
            _mlb = mlb;
        }

        [Command("listmusea")]
        [Alias("lm")]
        public async Task ListMuseums() {
            await RetrieveApiData();
            await Context.Channel.SendMessageAsync(_mlb.makeMuseumList());
        }

        [Command("getinfo")]
        [Alias("gi")]
        public async Task GetInfo(string name) {
            await RetrieveApiData();
            EmbedBuilder emb = _mlb.maakGroteEmbedMuseum(name);
            await Context.Channel.SendMessageAsync(embed: emb.Build());
        }

        [Command("rate")]
        public async Task MakeRate(string name) {
            await RetrieveApiData();
            await Context.Channel.SendMessageAsync($"test {name}");
        }


        private async Task RetrieveApiData() {
            string test = await _client.GetStringAsync("https://datatank.stad.gent/4/musea/toegankelijkheidsinfo.json");
            JArray obj = JArray.Parse(test);
            _map.parseToDomainAndPersist(obj);
        }
    }
}
