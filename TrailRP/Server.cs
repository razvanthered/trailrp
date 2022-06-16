using GTANetworkAPI;
using GTANetworkMethods;
using Player = GTANetworkAPI.Player;

namespace TrailRP
{
    public class Server : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Server.SetDefaultSpawnLocation(new Vector3(-725.15656, -910.2633, 19.259087), 141.38099f);
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            NAPI.Util.ConsoleOutput($"{player.Name} has connected");
            player.SendChatMessage($"{player.Name} has connected");
        }
    }
}