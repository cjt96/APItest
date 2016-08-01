using POGOProtos.Map.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogoLib.Wearable
{
    public class AndroidWear
    {
        private PogoClient _client;

        private string[] pokemonName;
        private string[] pokemonInfo;

        public string[] WearTitle
        {
            get { return pokemonName; }
            set { pokemonName = value; }
        }

        public string[] WearText
        {
            get { return pokemonInfo; }
            set { pokemonInfo = value; }
        }

        /// <summary>
        /// Initiate the class by providing the client.
        /// </summary>
        /// <param name="client"></param>
        public AndroidWear(PogoClient client)
        {
            _client = client;
            //GetEncounterablePokemon();
        }

        public void Refresh()
        {
            GetEncounterablePokemon();
        }

        private async void GetEncounterablePokemon()
        {
            var wildPokemon = await _client.GetWildPokemon();
            var test = from wpokes in wildPokemon
                       select wpokes.PokemonData.PokemonId.ToString();

            pokemonName = test.ToArray<string>();
            BuildPokemonInfo(wildPokemon);
        }

        private void BuildPokemonInfo(List<WildPokemon> wildPokemon)
        {
            List<string> information = new List<string>();
            foreach (var pokemon in wildPokemon)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("The pokemon despawns in {0}", GetMinutesAndSeconds(pokemon.TimeTillHiddenMs)));
                information.Add(sb.ToString());
            }
            pokemonInfo = information.ToArray<string>();
        }

        private string GetMinutesAndSeconds(int ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);
            string answer = string.Format("{0:D1}m:{1:D2}s",
                                    t.Minutes,
                                    t.Seconds);
            return answer;
        }
    }
}
