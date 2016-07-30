using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;
using PogoLib.Exceptions;
using PogoLib.Enums;
using POGOProtos.Data;
using POGOProtos.Map;
using Google.Protobuf.Collections;
using POGOProtos.Map.Pokemon;
using System.Reflection;

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
            List<NearbyPokemon> nearbyPokemon = new List<NearbyPokemon>();
            return await GetMapCellInformation(PropertyName.NearbyPokemons.ToString(), nearbyPokemon);
        }

        /// <summary>
        /// Gets the pokemon spawn points.
        /// </summary>
        /// <returns>List of spawn points.</returns>
        public async Task<List<SpawnPoint>> GetSpawnPoints()
        {
            List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
            return await GetMapCellInformation(PropertyName.SpawnPoints.ToString(), spawnPoints);
        }

        /// <summary>
        /// Get the catchable pokemon.
        /// </summary>
        /// <returns>List of catchable pokemon.</returns>
        public async Task<List<MapPokemon>> GetCatchablePokemon()
        {
            List<MapPokemon> mapPokemon = new List<MapPokemon>();
            return await GetMapCellInformation(PropertyName.CatchablePokemons.ToString(), mapPokemon);
        }

        /// <summary>
        /// Get wild pokemon.
        /// </summary>
        /// <returns>List of wild pokemon.</returns>
        public async Task<List<WildPokemon>> GetWildPokemon()
        {
            List<WildPokemon> wildPokemon = new List<WildPokemon>();
            return await GetMapCellInformation(PropertyName.WildPokemons.ToString(), wildPokemon);
        }

        /// <summary>
        /// Get information from the Map Cell.
        /// </summary>
        /// <typeparam name="T">Type to return.</typeparam>
        /// <param name="propName">Name of the property to return.</param>
        /// <param name="collection">Collection to fill.</param>
        /// <returns>Fills the collection with information.</returns>
        private async Task<List<T>> GetMapCellInformation<T>(string propName,List<T> collection)
        {
            RepeatedField<MapCell> mapCells = await GetMapCell();
            foreach (var mapCell in mapCells)
            {
                object obj = mapCell;
                PropertyInfo propInfo = obj.GetType().GetProperty(propName);
                object itemValue = propInfo.GetValue(obj, null);
                RepeatedField<T> infoCollection = (RepeatedField<T>)itemValue;

                if (infoCollection.Count != 0)
                {
                    collection.AddRange(infoCollection);
                }
            }
            return collection;
        }
    }
}
