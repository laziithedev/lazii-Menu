using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using Photon.Realtime;
using Photon;
using UnityEngine;
using laziiMenu.Classes;
using static NetworkSystem;
using UnityEngine.InputSystem;
using static laziiMenu.Menu.Main;

namespace laziiMenu.Mods
{
    internal class tagGun
    {

            public static void TagGun()
            {
                if (rightgrip || Mouse.current.rightButton.isPressed)
                {
                    Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out var Ray);
                    if (shouldBePC)
                    {
                        Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                        Physics.Raycast(ray, out Ray, 100);
                    }

                    GameObject NewPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    NewPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    NewPointer.GetComponent<Renderer>().material.color = (isCopying || (rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)) ? new Color(0,255,0,0) : new Color(255, 0, 0, 0);
                    NewPointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    NewPointer.transform.position = isCopying ? whoCopy.transform.position : Ray.point;
                    UnityEngine.Object.Destroy(NewPointer.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(NewPointer.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(NewPointer.GetComponent<Collider>());
                    UnityEngine.Object.Destroy(NewPointer, Time.deltaTime);

                    if (isCopying && whoCopy != null)
                    {
                        if (!whoCopy.mainSkin.material.name.Contains("fected"))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;

                            GorillaTagger.Instance.offlineVRRig.transform.position = whoCopy.transform.position - new Vector3(0f, 3f, 0f);
                            GorillaTagger.Instance.myVRRig.transform.position = whoCopy.transform.position - new Vector3(0f, 3f, 0f);

                            GorillaLocomotion.Player.Instance.rightControllerTransform.position = whoCopy.transform.position;

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

                            l.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0);
                            r.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0);

                            UnityEngine.Object.Destroy(l, Time.deltaTime);
                            UnityEngine.Object.Destroy(r, Time.deltaTime);
                        }
                        else
                        {
                            isCopying = false;
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                    }
                    if (rightTrigger > 0.5f || Mouse.current.leftButton.isPressed)
                    {
                        VRRig possibly = Ray.collider.GetComponentInParent<VRRig>();
                        if (possibly && possibly != GorillaTagger.Instance.offlineVRRig && !possibly.mainSkin.material.name.Contains("fected"))
                        {
                            if (PhotonNetwork.LocalPlayer.IsMasterClient)
                            {
                                foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                                {
                                    if (!gorillaTagManager.currentInfected.Contains(RigManager.GetPlayerFromVRRig(possibly)))
                                    {
                                        gorillaTagManager.currentInfected.Add(RigManager.GetPlayerFromVRRig(possibly));
                                    }
                                }
                            }
                            else
                            {
                                isCopying = true;
                                whoCopy = possibly;
                            }
                        }
                    }
                }
                else
                {
                    if (isCopying)
                    {
                        isCopying = false;
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
        }
    }
