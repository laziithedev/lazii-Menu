﻿using BepInEx;
using System.ComponentModel;

namespace laziiMenu.Patches
{
    [Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
        }
    }
}
