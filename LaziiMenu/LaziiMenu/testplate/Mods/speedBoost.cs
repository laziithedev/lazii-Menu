using System;
using System.Collections.Generic;
using System.Text;

namespace EclipseMenu.Mods
{
    internal class speedBoost
    {
        public static void SpeedBoost()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 9f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 9f;
        }
    }
}
