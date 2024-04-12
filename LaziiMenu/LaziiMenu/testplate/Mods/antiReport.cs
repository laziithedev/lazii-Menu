using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static EclipseMenu.Classes.RigManager;
using static EclipseMenu.Menu.Main;
using static EclipseMenu.Mods.RPCProt;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Linq;
using EclipseMenu.Notifications;


namespace EclipseMenu.Mods
{
    internal class antiReport
    {

        public static GorillaScoreBoard[] boards = null;
        public static GorillaScoreBoard[] currentboards = null;
        public static void AntiReportDisconnect()
        {
            try
            {
                if (boards == null)
                {
                    boards = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                    foreach (GorillaScoreBoard fix in boards)
                    {
                        if (!currentboards.Contains(fix))
                        {
                            List<GorillaScoreBoard> abc = currentboards.ToList();
                            abc.Add(fix);
                            currentboards = abc.ToArray();
                        }
                    }
                }
                foreach (GorillaScoreBoard board in currentboards)
                {
                    foreach (GorillaPlayerScoreboardLine line in board.lines)
                    {
                        if (line.linePlayer == NetworkSystem.Instance.LocalPlayer)
                        {
                            Transform report = line.reportButton.gameObject.transform;
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    float D1 = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                                    float D2 = Vector3.Distance(vrrig.leftHandTransform.position, report.position);

                                    float threshold = 0.35f;

                                    if (D1 < threshold || D2 < threshold)
                                    {
                                        PhotonNetwork.Disconnect();
                                        RPCProtection();
                                        NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { } // Not connected
        }

    }
}
