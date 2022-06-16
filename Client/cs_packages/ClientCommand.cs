using System;
using RAGE;

namespace Client
{
    public class ClientCommand : Events.Script
    {
        public ClientCommand()
        {
            Events.Add("SetSprintMultiplier", SetSprintMultiplier);
            Events.Add("FreezePlayer", FreezePlayer);
        }

        private void FreezePlayer(object[] args)
        {
            RAGE.Elements.Player.LocalPlayer.FreezePosition((bool)args[0]);
        }

        private void SetSprintMultiplier(object[] args)
        {
            var multiplier = (float)args[0];
            RAGE.Game.Player.SetRunSprintMultiplierForPlayer(multiplier);
        }
    }
}