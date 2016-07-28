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
using PogoLib;

namespace TestForm
{
    public partial class LogInForm : Form
    {
        PogoClient _client;
        public LogInForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _client = new PogoClient(190, 52.6276303, -2.1265187, "PogoTrackerCW", "SnHackable25@!");
                await _client.LogIn();
                var player = await _client.GetPlayerInformation();
                MessageBox.Show(string.Format("Logged in player {0}", player.Username));
                Mainform mainF = new Mainform();
                mainF._client = _client;
                mainF.Show();
            }
            catch (PokemonGo.RocketAPI.Exceptions.PtcOfflineException)
            {
                MessageBox.Show("PTC Servers are offline.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
