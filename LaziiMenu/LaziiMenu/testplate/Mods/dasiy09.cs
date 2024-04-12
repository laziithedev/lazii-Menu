using GorillaLocomotion.Gameplay;
using GorillaTag;
using HarmonyLib;
using laziiMenu.Notifications;
using Photon.Pun;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using static laziiMenu.Classes.RigManager;
using static laziiMenu.Menu.Main;
using static laziiMenu.Mods.RPCProt;


namespace laziiMenu.Mods
{
    internal class dasiy09
    {
        public static void BecomeDAISY09()
        {
            ChangeName("DAISY09");
            ChangeColor(new Color32(255, 81, 231, 255));
        }

        public static void BecomeJ3VU()
        {
            ChangeName("J3VU");
            ChangeColor(Color.green);
        }

        public static void BecomeBEES()
        {
            ChangeName("BEES");
            ChangeColor(Color.yellow);
        }

        public static void BecomeSTATUE()
        {
            ChangeName("STATUE");
            ChangeColor(Color.black);
            RPCProtection();
        }

        public static void BecomePBBV()
        {
            ChangeName("PBBV");
            ChangeColor(new Color32(230, 127, 102, 255));
        }

        public static void BecomeBANSHEE()
        {
            ChangeName("BANSHEE");
            ChangeColor(new Color32(255, 255, 255, 255));
        }

        public static void BecomeRUNRABBIT()
        {
            ChangeName("RUNRABBIT");
            ChangeColor(new Color32(230, 127, 102, 255));
        }

        public static void Becomelazii()
        {
            ChangeName("lazii");
            ChangeColor(new Color32(255, 255, 255, 255));
        }

        public static void BecomeECHO()
        {
            ChangeName("ECHO");
            ChangeColor(new Color32(0, 150, 255, 255));
        }

        public static void NONAME()
        {
            ChangeName("________");
            ChangeColor(new Color32(0, 53, 2, 255));
        }
    }
}
