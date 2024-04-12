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

        public static void GliderGun()
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
                    foreach (GliderHoldable glider in GetGliders())
                    {
                        glider.gameObject.transform.position = NewPointer.transform.position + new Vector3(0f, 1f, 0f);
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
