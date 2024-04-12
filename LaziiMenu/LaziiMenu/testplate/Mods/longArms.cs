using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static EclipseMenu.Menu.Buttons;

namespace EclipseMenu.Mods
{
    internal class longArms
    {
        public static void LongArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

        public static void LongArmsOff()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
