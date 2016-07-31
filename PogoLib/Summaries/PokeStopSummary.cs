using POGOProtos.Networking.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogoLib.Summaries
{
    public class PokeStopSummary : ISummary
    {
        private FortSearchResponse pokeStop;
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public FortSearchResponse PokeStop
        {
            get { return pokeStop; }
            set { pokeStop = value; }
        }

        public void CreateMessage()
        {
            StringBuilder sb = new StringBuilder();

            switch (pokeStop.Result)
            {
                case FortSearchResponse.Types.Result.NoResultSet:
                    sb.AppendLine("There was an error collecting the pokestop");
                    break;
                case FortSearchResponse.Types.Result.Success:
                    sb.AppendLine("The pokestop was captured successfully");
                    sb.AppendLine("The following rewards were received:");
                    sb.AppendLine(string.Format("XP = {0}", pokeStop.ExperienceAwarded));
                    sb.AppendLine(string.Format("Items:{0}", GetReceivedItems()));
                    sb.AppendLine(pokeStop.GemsAwarded.ToString());
                    break;
                case FortSearchResponse.Types.Result.OutOfRange:
                    sb.AppendLine("The pokestop is out of range");
                    break;
                case FortSearchResponse.Types.Result.InCooldownPeriod:
                    sb.AppendLine(string.Format("The pokestop has already been taken. Cooldown time = {0}", ConvertMillisecondsToMinutes(pokeStop.CooldownCompleteTimestampMs)));
                    break;
                case FortSearchResponse.Types.Result.InventoryFull:
                    sb.AppendLine("Inventory is full.");
                    break;
                default:
                    break;
            }
            message += sb.ToString();
        }

        private string GetReceivedItems()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in pokeStop.ItemsAwarded)
            {
                sb.AppendLine(string.Format("{0} x{1}", item.ItemId.ToString().Replace("item",string.Empty), item.ItemCount));
            }
            return sb.ToString();
        }

        private static double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }
    }
}
