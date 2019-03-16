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

        }
    }
}
