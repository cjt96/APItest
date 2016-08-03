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
    public partial class UpdateLocation : Form
    {
        public PogoLib.PogoClient _client;
        private double altitude;
        public double Altitude
        {
            get { return altitude; }
        }
        public UpdateLocation()
        {
            InitializeComponent();

        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            double latitude = Convert.ToDouble(txtLat.Text);
            double longitude = Convert.ToDouble(txtLong.Text);
            altitude = Math.Round(altitude, 0) == 0 ? 150 : altitude;
            await _client.UpdatePlayerLocation(latitude, longitude, altitude);
            Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            KeyValuePair<string, string> location = (KeyValuePair<string,string>)listBox1.SelectedItem;
            txtLat.Text = location.Key;
            txtLong.Text = location.Value;
        }
    }
}
