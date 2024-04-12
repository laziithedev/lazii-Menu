using laziiMenu.Notifications;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static laziiMenu.Classes.RigManager;
using static laziiMenu.Menu.Main;
using static laziiMenu.Mods.RPCProt;
using UnityEngine.SceneManagement;
using Photon.Realtime;


namespace laziiMenu.Mods
{
    internal class antiReport
    {

        public static GorillaScoreBoard[] boards = null;
        public static void AntiReportDisconnect()
        {
            try
            {
                if (boards == null)
                {
                    boards = GameObject.FindObjectsOfType<GorillaScoreBoard>();
                }
                foreach (GorillaScoreBoard board in boards)
                {
                    foreach (GorillaPlayerScoreboardLine line in board.lines)
                    {
                        if (GetPlayerFromNetPlayer(line.linePlayer) == PhotonNetwork.LocalPlayer)
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
