using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace laziiMenu.Mods
{
    internal class networkTriggers
    {
        public static void EnableNetworkTriggers()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
        }

        public static void DisableNetworkTriggers()
        {
            GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
        }
    }
}
