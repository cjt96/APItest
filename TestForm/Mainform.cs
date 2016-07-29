using PogoLib;
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
            List<NearbyPokemon> nearbyPokemon = await _client.GetNearbyPokemon();
            InfoForm info = new InfoForm();
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

            info.richTextBox1.Text = sb.ToString();
            info.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            listBox1.Items.Add(textBox1.Text);
        }
    }
}
