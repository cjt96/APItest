using Microsoft.VisualStudio.TestTools.UnitTesting;
using PogoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogoLib.Tests
{
    [TestClass()]
    public class PogoClientTests
    {
        PogoClient client = new PogoClient(396, 52.602837, -2.129197, "PogoTrackerCW", "SnHackable25@!");
        [TestMethod()]
        public void PogoClientTest()
        {
            PogoClient clientTest = new PogoClient(396, 52.602837, -2.129197, "PogoTrackerCW", "SnHackable25@!");
            Assert.IsNotNull(clientTest);
        }

        [TestMethod()]
        public void PogoClientTest1()
        {
            //PogoClient client = new PogoClient(396, 52.602837, -2.129197, "PogoTrackerCW", "SnHackable25@!");
            //Assert.IsNotNull(client);
        }

        [TestMethod()]
        public async void LogInTest()
        {
            await client.LogIn();
            Assert.IsTrue(client.LoggedIn);
        }

        [TestMethod()]
        public async void GetPlayerInformationTest()
        {
            var playerData = await client.GetPlayerInformation();
            Assert.IsNotNull(playerData.Username);
        }

        [TestMethod()]
        public async void GetNearbyPokemonTest()
        {
            var nearbyPokemon = await client.GetNearbyPokemon();
            Assert.IsNotNull(nearbyPokemon);
        }
    }
}