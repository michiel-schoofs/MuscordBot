using MuscordBot.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

                if(_museumRepo.getByName(m.Naam)==null)
                    _museumRepo.add(m);
            }

            _museumRepo.SaveChanges();
        }
    }
}
