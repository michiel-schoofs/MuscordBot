using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuscordBot.Data.Connection {
    [Name("Museum commands")]
    public class MuseumModule : ModuleBase<SocketCommandContext> {
        private HttpClient _client;

        public MuseumModule() {
            _client = ConnectionJson.APIClient;
        }

        [Command("list musseum")]
        [Alias("lm")]
        public async Task listMuseums() {
            string test = await _client.GetStringAsync("https://datatank.stad.gent/4/musea/toegankelijkheidsinfo.json");
            JArray obj = JArray.Parse(test);
           
        }
    }
}
