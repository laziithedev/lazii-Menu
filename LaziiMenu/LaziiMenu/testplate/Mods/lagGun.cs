using ExitGames.Client.Photon;
using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using GorillaTag;
using HarmonyLib;
using System.Reflection;
using UnityEngine.InputSystem.LowLevel;
using static EclipseMenu.Menu.Main;
using static EclipseMenu.Classes.RigManager;
using static EclipseMenu.Mods.RPCProt;
using EclipseMenu.Notifications;

namespace EclipseMenu.Mods
{
    internal class lagGun
    {
        public static void laggun()
        {
            if (rightgrip)
            {
                Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);
                if (shouldBePC)
                {
                    Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                    Physics.Raycast(ray, out Ray, 100);
                }

                GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                NewPointer.GetComponent<Renderer>().material.color = Color.red;
                NewPointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                NewPointer.transform.position = Ray.point;
                Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                Object.Destroy(NewPointer.GetComponent<Collider>());
                Object.Destroy(NewPointer, Time.deltaTime);
                if (isCopying && whoCopy != null)
                {
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        ScienceExperimentManager.instance.photonView.RPC("SpawnSodaBubbleRPC", GetPlayerFromVRRig(whoCopy), new object[]
                        {
                            new Vector2(0.3f, 0.3f),
                            2f,
                            10f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : (double)Time.time
                        });
                        RPCProtection();
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master.</color>");
                    }
                }
                if (rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)
                {
                    VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                    if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                    {
                        isCopying = true;
                        whoCopy = possibly;
                    }
                }


            }
            else
            {
                if (isCopying)
                {
                    isCopying = false;
                }
            }
        }
    }
}
