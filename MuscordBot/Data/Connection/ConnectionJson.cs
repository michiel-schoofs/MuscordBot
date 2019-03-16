using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MuscordBot.Data {
    public static class ConnectionJson {
        public static HttpClient APIClient { get; private set; }
        public static void InitializeClient() {
            if (APIClient == null)
                APIClient = new HttpClient();

            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
