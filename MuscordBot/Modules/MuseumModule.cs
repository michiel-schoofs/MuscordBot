using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MuscordBot.Data.Parsers;
using Newtonsoft.Json;
using MuscordBot.Domain;

namespace MuscordBot.Data.Connection {
    [Name("Museum commands")]
    public class MuseumModule : ModuleBase<SocketCommandContext> {
        private HttpClient _client;
        private Museum_Accesability_Parser _map;
        public MuseumModule(Museum_Accesability_Parser map) {
            _client = ConnectionJson.APIClient;
            _map = map;
        }

        [Command("list musseum")]
        [Alias("lm")]
        public async Task listMuseums() {
            string test = await _client.GetStringAsync("https://datatank.stad.gent/4/musea/toegankelijkheidsinfo.json");
            JArray obj = JArray.Parse(test);
            _map.parseToDomainAndPersist(obj);
        }
    }
}
