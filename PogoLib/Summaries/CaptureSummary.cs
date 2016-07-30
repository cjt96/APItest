using POGOProtos.Data;
using POGOProtos.Data.Capture;
using POGOProtos.Networking.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogoLib.Summaries
{
    public class CaptureSummary
    {
        private bool success;
        private EncounterResponse encounterResponse;
        private string messsage;
        private CatchPokemonResponse.Types.CatchStatus catchStatus;
        private CaptureAward captureAward;
        private ulong capturedPokemonId;
        private PokemonData pokemonData;

        public PokemonData PokeData
        {
            get { return pokemonData; }
            set { pokemonData = value; }
        }

        public ulong CapturedPokemonId
        {
            get { return capturedPokemonId; }
            set { capturedPokemonId = value; }
        }
        
        public CaptureAward CaptureAward
        {
            get { return captureAward; }
            set { captureAward = value; }
        }

        public CatchPokemonResponse.Types.CatchStatus CatchStatus
        {
            get { return catchStatus; }
            set { catchStatus = value; }
        }

        public string Message
        {
            get { return messsage; }
            set { messsage = value; }
        }

        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public CaptureSummary(EncounterResponse encounter)
        {
            encounterResponse = encounter;
            pokemonData = encounterResponse.WildPokemon.PokemonData;
        }

        public void CreateMessage()
        {
            StringBuilder sb = new StringBuilder();
            BuildEncounterPart(sb);
            BuildCapturePart(sb);
            messsage = sb.ToString();
        }

        private void BuildEncounterPart(StringBuilder sb)
        {
            switch (encounterResponse.Status)
            {
                case EncounterResponse.Types.Status.EncounterError:
                    sb.AppendLine("There was an error with the encounter.");
                    break;
                case EncounterResponse.Types.Status.EncounterSuccess:
                    sb.AppendLine(string.Format("The encounter with {0} was successful.", pokemonData.PokemonId.ToString()));
                    sb.AppendLine(string.Format("CP = {0}", pokemonData.Cp));
                    break;
                case EncounterResponse.Types.Status.EncounterNotFound:
                    sb.AppendLine("The pokemon is no longer available.");
                    break;
                case EncounterResponse.Types.Status.EncounterClosed:
                    sb.AppendLine("The encounter has ended.");
                    break;
                case EncounterResponse.Types.Status.EncounterPokemonFled:
                    sb.AppendLine(string.Format("{0} ran away.", encounterResponse.WildPokemon.PokemonData.PokemonId.ToString()));
                    break;
                case EncounterResponse.Types.Status.EncounterNotInRange:
                    sb.AppendLine("The pokemon is too far away to encounter.");
                    break;
                case EncounterResponse.Types.Status.EncounterAlreadyHappened:
                    sb.AppendLine("The encounter has already happened.");
                    break;
                case EncounterResponse.Types.Status.PokemonInventoryFull:
                    sb.AppendLine("Pokemon inventory full.");
                    break;
                default:
                    break;
            }
        }

        private void BuildCapturePart(StringBuilder sb)
        {
            switch (catchStatus)
            {
                case CatchPokemonResponse.Types.CatchStatus.CatchError:
                    sb.AppendLine("There was an error while trying to capture the pokemon");
                    break;
                case CatchPokemonResponse.Types.CatchStatus.CatchSuccess:
                    sb.AppendLine("The pokemon was captured successfully");
                    sb.AppendLine(string.Format("The account received the following rewards:{0}XP = {1}{0}Stardust = {2}{0}Candy = {3}", Environment.NewLine, captureAward.Xp, captureAward.Stardust, captureAward.Candy));
                    break;
                case CatchPokemonResponse.Types.CatchStatus.CatchEscape:
                    sb.AppendLine("The pokemon excaped the ball");
                    break;
                case CatchPokemonResponse.Types.CatchStatus.CatchFlee:
                    sb.AppendLine("The pokemon ran away.");
                    break;
                case CatchPokemonResponse.Types.CatchStatus.CatchMissed:
                    sb.AppendLine("The ball missed.");
                    break;
                default:
                    break;
            }
        }
    }
}
