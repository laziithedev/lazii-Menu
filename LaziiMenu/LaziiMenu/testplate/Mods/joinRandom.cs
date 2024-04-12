using GorillaNetworking;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Diagnostics;
using static laziiMenu.Menu.Main;
using static laziiMenu.Mods.Reconnect;

namespace laziiMenu.Mods
{
    internal class joinRandom
    {
        public static void JoinRandom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.Disconnect();
                isJoiningRandom = true;
                jrDebounce = Time.time + internetFloat;
            }
            else
            {
                GameObject forest = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
                GameObject city = GameObject.Find("Environment Objects/LocalObjects_Prefab/City");
                GameObject canyons = GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon");
                GameObject mountains = GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain");
                GameObject beach = GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach");
                GameObject sky = GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle");
                GameObject basement = GameObject.Find("Environment Objects/LocalObjects_Prefab/Basement");
                GameObject caves = GameObject.Find("Environment Objects/LocalObjects_Prefab/Cave_Main_Prefab");

                if (forest.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (city.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - City Front").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (canyons.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (mountains.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Mountain For Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (beach.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Beach from Forest").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (sky.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Clouds").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (basement.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Basement For Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
                if (caves.activeSelf == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab/JoinPublicRoom - Cave").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                }
            }
        }
    }
}
        
