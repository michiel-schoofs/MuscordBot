using MuscordBot.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MuscordBot.Data.Parsers {
    public class Museum_Accesability_Parser {
        private IMuseumRepo _museumRepo;

        public Museum_Accesability_Parser(IMuseumRepo repo) {
            _museumRepo = repo;
        }

        public void parseToDomainAndPersist(JArray ja) {
            foreach (JObject j in ja) {
                Museum m = new Museum();
                m.Naam = j.GetValue("Museum").ToString();
                Accesability a = new Accesability();
                var s = j.GetValue("Is het museum rolstoeltoegankelijk?").ToString();
                a.wheelchairAc = s.Equals("volledig") ? true : false;
                s = j.GetValue("Zijn er parkeerplaatsen voor mensen met handicap/beperkingen in de omgeving van het museum?").ToString();
                a.aangepasteParking = s.StartsWith("Ja") ? true : false;
                s = j.GetValue("Hoeveel liften zijn er aanwezig?").ToString();
                a.liften = int.Parse(s.Equals("?")?"0":s);
                a.aangepasteToilleten = int.Parse(j.GetValue("Hoeveel permanente aangepaste toiletten zijn er aanwezig?").ToString());
                m.Accesability = a;

                JsonReader reader = new JsonTextReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\","prototype.json")));
                var jo = JArray.ReadFrom(reader);

                foreach (var x in jo) {
                    var l = x.Value<JToken>("name");
                    var name = l.Value<JArray>("nl");

                    var nameStr = name[0].ToString();


                    if (m.Naam.Trim().ToLower().Equals(nameStr.ToLower())) {
                         l = x.Value<JToken>("description");
                        name = l.Value<JArray>("nl");
                        m.Description = name[0].ToString();

                        l = x.Value<JArray>("image");
                        JToken jt = l.First;
                        m.AfbeeldingUrl = jt.Value<string>("url");

                        m.Url = x.Value<string>("url");
                    }

                }

                if (_museumRepo.getByName(m.Naam)==null)
                    _museumRepo.add(m);
            }

            _museumRepo.SaveChanges();
        }
    }
}
