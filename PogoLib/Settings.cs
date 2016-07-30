using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;

namespace PogoLib
{
    class Settings : ISettings
    {
        private double defaultAltitude;
        private double defaultLatitude;
        private double defaultLongitude;
        private string googleRefreshToken;
        private string ptcUsername;
        private string ptcPassword;
        private AuthType authType;

        public Settings(double defaultAlt, double defaultLat, double defaultLong, string refreshToken)
        {
            defaultAltitude = defaultAlt;
            defaultLatitude = defaultLat;
            defaultLongitude = defaultLong;
            googleRefreshToken = refreshToken;
        }

        public Settings(double defaultAlt, double defaultLat, double defaultLong, string username, string password)
        {
            defaultAltitude = defaultAlt;
            defaultLatitude = defaultLat;
            defaultLongitude = defaultLong;
            ptcUsername = username;
            ptcPassword = password;
        }

        public AuthType AuthType
        {
            get { return authType; }
            set { authType = value; }
        }

        public double DefaultAltitude
        {
            get { return defaultAltitude; }
        }

        public double DefaultLatitude
        {
            get { return defaultLatitude; }
        }

        public double DefaultLongitude
        {
            get { return defaultLongitude; }
        }

        public string GoogleRefreshToken
        {
            get { return googleRefreshToken; }
            set { googleRefreshToken = value; }
        }

        public string PtcPassword
        {
            get { return ptcPassword; }
        }

        public string PtcUsername
        {
            get { return ptcUsername; }
        }
    }
}
