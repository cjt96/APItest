using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;

namespace APItest
{
    class TestClass
    {
        private Client Client;

        public TestClass(Client client)
        {
            Client = client;
        }

        public async Task<string> DoLogin()
        {
            await Client.Login.DoPtcLogin();
            var player = await Client.Player.GetPlayer();
            return player.PlayerData.Username;
        }
    }
}
