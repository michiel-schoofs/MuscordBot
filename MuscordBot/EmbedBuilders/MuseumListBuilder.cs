using Discord;
using MuscordBot.Domain;
using System.Text;
using System.Threading.Tasks;

namespace MuscordBot.EmbedBuilders {
    public class MuseumListBuilder {
        private IMuseumRepo repo;

        public MuseumListBuilder(IMuseumRepo _repo) {
            repo = _repo;
        }

        public string makeMuseumList() {
            StringBuilder sb = new StringBuilder();
            sb.Append("```diff\n");

            foreach (var m in repo.getAll()) {
                sb.Append($"+ {m.Naam}\n");
            }

            sb.Append("```");
            return sb.ToString();
        }


        public EmbedBuilder maakGroteEmbedMuseum(string naam) {
            EmbedBuilder em = new EmbedBuilder();
            Museum m = repo.getByName(naam);

            em.Title = m.Naam;
            em.Description = "Beschrijving hier";
            Accesability a = m.Accesability;
            em.WithColor(Color.DarkPurple);

            em.AddField("Aantal liften", a.liften,true);
            em.AddField("Aantal aangepaste toiletten", a.aangepasteToilleten,true);

            em.AddField("Icons", "♿ 🅿️", false);

            EmbedFooterBuilder efb = new EmbedFooterBuilder();
            efb.WithText("Mogelijk gemaakt door Linked Open Data Gent");

            em.WithFooter(efb);

            return em;
        }
    }
}
