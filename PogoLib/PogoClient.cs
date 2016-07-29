using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;
using PogoLib.Exceptions;
using POGOProtos.Data;
using POGOProtos.Map;
using Google.Protobuf.Collections;
using POGOProtos.Map.Pokemon;

namespace PogoLib
{
    public class PogoClient
    {
        private Client _client;
        private Settings _settings;
        private AuthType _authType;
        private bool _loggedIn;

        public bool LoggedIn
        {
            get
            {
                return _loggedIn;
            }
            set
            {
                _loggedIn = value;
            }
        }

        #region Constructors
        /// <summary>
        /// Initiate the PogoClient ready for google authentication.
        /// </summary>
        /// <param name="defaultAlt">Altitude.</param>
        /// <param name="defaultLat">Latitude.</param>
        /// <param name="defaultLong">Longitude.</param>
        /// <param name="refreshToken">Google refresh token.</param>
        /// <remarks>Not implemented yet.</remarks>
        public PogoClient(double defaultAlt, double defaultLat, double defaultLong, string refreshToken)
        {
            _settings = new Settings(defaultAlt, defaultLat, defaultLong, refreshToken);
            _authType = AuthType.Google;
        }

        /// <summary>
        /// Initiate the PogoClient ready for PTC authentication.
        /// </summary>
        /// <param name="defaultAlt">Altitude.</param>
        /// <param name="defaultLat">Latitude.</param>
        /// <param name="defaultLong">Longitude.</param>
        /// <param name="username">PTC Username.</param>
        /// <param name="password">PTC Password.</param>
        public PogoClient(double defaultAlt, double defaultLat, double defaultLong, string username, string password)
        {
            _settings = new Settings(defaultAlt, defaultLat, defaultLong, username, password);
            _authType = AuthType.Ptc;
        }
        #endregion

        #region Log In
        /// <summary>
        /// Log into the server.
        /// </summary>
        public async Task LogIn()
        {
            switch (_authType)
            {
                case AuthType.Google:
                    _loggedIn = await GoogleLogIn();
                    break;
                case AuthType.Ptc:
                    _loggedIn = await PtcLogIn();
                    break;
                default:
                    _loggedIn = false;
                    break;
            }
        }
        /// <summary>
        /// Log in using PTC
        /// </summary>
        /// <returns>True if successful.</returns>
        private async Task<bool> PtcLogIn()
        {
            _client = new Client(_settings);
            await _client.Login.DoPtcLogin();
            if (_client != null) return true;
            return false;
        }
        /// <summary>
        /// Log in using Google.
        /// </summary>
        /// <returns>True if successful.</returns>
        private async Task<bool> GoogleLogIn()
        {
            throw new NotImplementedException("I haven't done this yet");
        }
        #endregion

        /// <summary>
        /// Return information about the player.
        /// </summary>
        /// <returns>POGOProtos player data.</returns>
        public async Task<PlayerData> GetPlayerInformation()
        {
            if (!_loggedIn) throw new NotLoggedInException();
            var player = await _client.Player.GetPlayer();
            return player.PlayerData;
        }

        /// <summary>
        /// Get all data from the Map Cell
        /// </summary>
        /// <returns>The map cell.</returns>
        /// <remarks>Unsure whether to expose this.</remarks>
        private async Task<RepeatedField<MapCell>> GetMapCell()
        {
            if (!_loggedIn) throw new NotLoggedInException();
            var mapObjs = await _client.Map.GetMapObjects();
            return mapObjs.MapCells;
        }

        /// <summary>
        /// Returns a list of nearby pokemon.
        /// </summary>
        /// <returns>A list of nearby pokemon.</returns>
        public async Task<List<NearbyPokemon>> GetNearbyPokemon()
        {
            RepeatedField<MapCell> mapCells = await GetMapCell();
            List<NearbyPokemon> nearbyPokemon = new List<NearbyPokemon>();

            if (mapCells.Count != 0)
            {
                foreach (var mapCell in mapCells)
                {
                    if (mapCell.NearbyPokemons.Count != 0)
                    {
                        nearbyPokemon.AddRange(mapCell.NearbyPokemons);
                    }
                }
            }
            return nearbyPokemon;
        }

        public async Task<List<SpawnPoint>> GetSpawnPoints()
        {
            RepeatedField<MapCell> mapCells = await GetMapCell();
            List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

            if (mapCells.Count != 0)
            {
                foreach (var mapCell in mapCells)
                {
                    if (mapCell.SpawnPoints.Count != 0)
                    {
                        spawnPoints.AddRange(mapCell.SpawnPoints);
                    }
                }
            }
            return spawnPoints;
        }
    }
}
