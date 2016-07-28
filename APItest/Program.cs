using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;
using System.Net;
using System.Net.Http;

namespace APItest
{
    class Program
    {
        static void Main(string[] args)
        {
            Block();
        }

        async static Task Block()
        {
            Settings settings = new Settings(396, 52.602837, -2.129197, "PogoTrackerCW", "SnHackable25@!");
            Client client = new Client(settings);
            TestClass test = new TestClass(client);
            await test.DoLogin();
        }

        //private static async Task DoLogin(Client client)
        //{
        //    await client.Login.DoPtcLogin();
        //    var player = await client.Player.GetPlayer();
        //    Console.WriteLine(player.PlayerData.Username);
        //}
    }
}
