using System;
using RAGE;

namespace Client
{
    public class ClientCommand : Events.Script
    {
        public ClientCommand()
        {
            Events.Add("SetSprintMultiplier", SetSprintMultiplier);
        }

        private void SetSprintMultiplier(object[] args)
        {
            var multiplier = (float)args[0];
            RAGE.Game.Player.SetRunSprintMultiplierForPlayer(multiplier);
        }
    }
}