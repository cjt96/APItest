using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGo.RocketAPI.Xamarin_Workaround;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.RocketAPI.Xamarin_Workaround.Tests
{
    [TestClass()]
    public class XamarinHttpUtilityTests
    {
        [TestMethod()]
        public void ParseQueryStringTest()
        {
            var id = XamarinHttpUtility.ParseQueryString("?ticket=ST-11591282-iieTo3dbQINlUnSG7bIt-sso.pokemon.com")["ticket"];
            Assert.AreEqual<string>("ST-11591282-iieTo3dbQINlUnSG7bIt-sso.pokemon.com", id);
        }

        [TestMethod()]
        public void ParseQueryStringTest2()
        {
            var id = XamarinHttpUtility.ParseQueryString("access_token=TGT-541138-cJgqSbvosRiEVJoQ1AJSN4mLVqMsKLG4RD0ofqCW2h9Ti9z15W-sso.pokemon.com&expires=7197")["access_token"];
            Assert.AreEqual<string>("TGT-541138-cJgqSbvosRiEVJoQ1AJSN4mLVqMsKLG4RD0ofqCW2h9Ti9z15W-sso.pokemon.com", id);
        }
    }
}