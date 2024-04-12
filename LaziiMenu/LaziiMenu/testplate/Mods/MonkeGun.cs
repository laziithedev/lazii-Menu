using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using static NetworkSystem;
using UnityEngine.InputSystem;
using UnityEngine;
using ExitGames.Client.Photon;
using GorillaNetworking;
using laziiMenu.Notifications;
using Photon.Realtime;
using PlayFab.ClientModels;
using PlayFab;
using System.Text.RegularExpressions;
using UnityEngine.Windows;
using GorillaTag;
using HarmonyLib;
using System.Reflection;
using UnityEngine.InputSystem.LowLevel;
using static laziiMenu.Menu.Main;
using static laziiMenu.Classes.RigManager;
using static laziiMenu.Mods.RPCProt;
using laziiMenu.Classes;

namespace laziiMenu.Mods
{
    internal class MonkeGun
    {
        public static void monkeGun()
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
                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        if(rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)
                {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = NewPointer.transform.position + new Vector3(0, 1, 0);
                            GorillaTagger.Instance.myVRRig.transform.position = NewPointer.transform.position + new Vector3(0, 1, 0);

                            GameObject l = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            UnityEngine.Object.Destroy(l.GetComponent<Rigidbody>());
                            UnityEngine.Object.Destroy(l.GetComponent<SphereCollider>());

                            l.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            l.transform.position = GorillaTagger.Instance.leftHandTransform.position;

                            GameObject r = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            UnityEngine.Object.Destroy(r.GetComponent<Rigidbody>());
                            UnityEngine.Object.Destroy(r.GetComponent<SphereCollider>());

                            r.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            r.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                            l.GetComponent<Renderer>().material.color = new Color(0,255,0,0);
                            r.GetComponent<Renderer>().material.color = new Color(255,0,0,0);

                            UnityEngine.Object.Destroy(l, Time.deltaTime);
                            UnityEngine.Object.Destroy(r, Time.deltaTime);
                        }
                else
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                    }
                }


            }
        }
    
    }
}
