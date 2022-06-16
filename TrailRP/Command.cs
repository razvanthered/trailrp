using System;
using GTANetworkAPI;

namespace TrailRP
{
    public class Command : Script
    {
        [Command("relog", "~o~Usage: /relog", GreedyArg = true)]
        public void Relog_Command(Player player)
        {
            player.KickSilent();
        }
        
        [Command("getpos", "~o~Usage: /getpos", GreedyArg = true)]
        public void GetPos_Command(Player player)
        {
            NAPI.Util.ConsoleOutput($"{player.Name}'s position is {player.Position}");
            NAPI.Util.ConsoleOutput($"{player.Name}'s heading is {player.Heading}");
        }

        [Command("freeze")]
        public void Freeze_Command(Player player, Player target, bool freeze)
        {
            NAPI.ClientEvent.TriggerClientEvent(target, "FreezePlayer", freeze);
            
        }
        
        [Command("SetSprintMultiplier", "~o~Usage: ~w~/setSprintMultiplier [value]", Alias = "ssm", GreedyArg = true)]
        public void SetMultiplier_Command(Player player, string value)
        {
            float convertedValue = 1f;
            var success = float.TryParse(value, out convertedValue);

            if (!success)
            {
                player.SendChatMessage($"Invalid value: {value}");
                return;
            }
            
            NAPI.ClientEvent.TriggerClientEvent(player, "SetSprintMultiplier", Convert.ToSingle(convertedValue));   
            player.SendChatMessage($"Your sprint speed has been set to {convertedValue}!");
        }
        
        [Command("veh")]
        public static void CommandDebugVehicle(Player player, string vehicleName = "sultan2")
        {
            uint.TryParse(vehicleName, out uint vehicleHash);
            if (vehicleHash <= 0)
                vehicleHash = NAPI.Util.GetHashKey(vehicleName);

            Vehicle veh = NAPI.Vehicle.CreateVehicle(vehicleHash, player.Position, player.Rotation.Z, 0, 0);

            NAPI.Task.Run(() => { NAPI.Player.SetPlayerIntoVehicle(player, veh, 0); }, 200);
        }
    }
}