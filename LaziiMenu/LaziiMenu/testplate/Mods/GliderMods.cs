using System;
using System.Collections.Generic;
using System.Text;
using static laziiMenu.Menu.Main;
using ExitGames.Client.Photon;
using GorillaLocomotion.Gameplay;
using GorillaTag;
using GorillaTag.Cosmetics;
using HarmonyLib;
using laziiMenu.Notifications;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity.UtilityScripts;
using POpusCodec.Enums;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace laziiMenu.Mods
{
    internal class GliderMods
    {
        public static void GrabGliders()
        {
            if (rightgrip)
            {
                foreach (GliderHoldable glider in GetGliders())
                {
                    glider.gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                }
            }
        }
    }
}
