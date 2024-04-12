using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Oculus;
using GorillaTag;
using laziiMenu.Notifications;
using Photon.Pun;
using static NetworkSystem;
using ExitGames.Client.Photon;
using GorillaNetworking;
using laziiMenu.Notifications;
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
using static laziiMenu.Menu.Main;
using static laziiMenu.Classes.RigManager;
using static laziiMenu.Mods.RPCProt;
using UnityEngine.InputSystem;

namespace laziiMenu.Mods
{
    internal class VibrateGun
    {
        public static void vibrateGun()
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
                UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);
                if (isCopying && whoCopy != null)
                {
                    OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
                    OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.LTouch);
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
