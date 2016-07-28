using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonGo.RocketAPI;

namespace TestForm
{
    public partial class Form1 : Form
    {
        Client _client;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Logging in...";
            Settings settings = new Settings(396, 52.602837, -2.129197, textBox1.Text, textBox2.Text);
            _client = new Client(settings);
            await DoLogin();
        }

        private async Task DoLogin()
        {
            await _client.Login.DoPtcLogin();
            label1.Text = "Logged in. Getting player name.";
            var player = await _client.Player.GetPlayer();
            textBox1.Text = player.PlayerData.Username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
