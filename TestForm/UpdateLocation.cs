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
        public UpdateLocation()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double latitude = Convert.ToDouble(txtLat.Text);
            double longitude = Convert.ToDouble(txtLong.Text);
            _client.UpdatePlayerLocation(latitude, longitude, 300);
            this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            KeyValuePair<string, string> location = (KeyValuePair<string,string>)listBox1.SelectedItem;
            txtLat.Text = location.Key;
            txtLong.Text = location.Value;
        }
    }
}
