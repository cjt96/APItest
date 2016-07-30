using PogoLib;
using PogoLib.Summaries;
using POGOProtos.Map;
using POGOProtos.Map.Pokemon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Mainform : Form
    {
        public PogoClient _client;

        public Mainform()
        {
            InitializeComponent();
        }

        private async void btnPokeNear_Click(object sender, EventArgs e)
        {
            InfoForm _info = new InfoForm();
            List<NearbyPokemon> nearbyPokemon = await _client.GetNearbyPokemon();
            StringBuilder sb = new StringBuilder();

            foreach (var pokemon in nearbyPokemon)
            {
                if (!listBox1.Items.Contains(pokemon.PokemonId.ToString()))
                {
                    sb.AppendLine(pokemon.DistanceInMeters.ToString());
                    sb.AppendLine(pokemon.EncounterId.ToString());
                    sb.AppendLine(pokemon.PokemonId.ToString());
                    sb.AppendLine();
                    sb.AppendLine();
                }
            }

            _info.richTextBox1.Text = sb.ToString();
            _info.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            listBox1.Items.Add(textBox1.Text);
        }

        private async void btnGetSpawn_Click(object sender, EventArgs e)
        {
            InfoForm _info = new InfoForm();
            List<SpawnPoint> spawnPoints = await _client.GetSpawnPoints();
            StringBuilder sb = new StringBuilder();

            foreach (var spawn in spawnPoints)
            {
                sb.AppendLine(spawn.Latitude.ToString());
                sb.AppendLine(spawn.Longitude.ToString());
                sb.AppendLine();
                sb.AppendLine();
            }

            _info.richTextBox1.Text = sb.ToString();
            _info.Show();
        }

        private async void btnGetWild_Click(object sender, EventArgs e)
        {
            InfoForm _info = new InfoForm();
            List<WildPokemon> wildPokemon = await _client.GetWildPokemon();
            StringBuilder sb = new StringBuilder();

            foreach (var pokemon in wildPokemon)
            {
                sb.AppendLine(string.Format("Latitude {0}, Longitude {1}", pokemon.Latitude, pokemon.Longitude));
                sb.AppendLine(string.Format("Encounter ID = {0}", pokemon.EncounterId.ToString()));
                sb.AppendLine(string.Format("Spawn Point ID = {0}", pokemon.SpawnPointId.ToString()));
                sb.AppendLine(string.Format("Time until despawn = {0}mins", ConvertMillisecondsToMinutes(pokemon.TimeTillHiddenMs).ToString()));
                sb.AppendLine(string.Format("Pokemon CP = {0}", pokemon.PokemonData.Cp.ToString()));
                sb.AppendLine();
                sb.AppendLine();
            }

            _info.richTextBox1.Text = sb.ToString();
            _info.Show();
        }

        private async void btnGetCatchable_Click(object sender, EventArgs e)
        {
            InfoForm _info = new InfoForm();
            List<MapPokemon> catchablePokemon = await _client.GetCatchablePokemon();
            StringBuilder sb = new StringBuilder();

            foreach (var pokemon in catchablePokemon)
            {
                CaptureSummary captured = await _client.CaptureSpawnedPokemon(pokemon.EncounterId, pokemon.SpawnPointId, POGOProtos.Inventory.Item.ItemId.ItemPokeBall);
                captured.CreateMessage();
                sb.AppendLine(captured.Message);
            }

            _info.richTextBox1.Text = sb.ToString();
            _info.Show();
        }

        private static double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UpdateLocation ul = new UpdateLocation();
            List<SpawnPoint> spawnPoints = await _client.GetSpawnPoints();

            foreach (var spawn in spawnPoints)
            {
                ul.listBox1.Items.Add(new KeyValuePair<string, string>(spawn.Latitude.ToString(), spawn.Longitude.ToString()));
            }
            ul._client = _client;
            ul.Show();
        }
    }
}
