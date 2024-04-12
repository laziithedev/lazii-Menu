using BepInEx;
using ExitGames.Client.Photon;
using GorillaNetworking;
using HarmonyLib;
using laziiMenu;
using laziiMenu.Notifications;
using laziiMenu.Mods;
using Oculus.Platform;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using static laziiMenu.Menu.Buttons;
using static laziiMenu.Menu.Settings;
using laziiMenu.Classes;
using static laziiMenu.Mods.RPCProt;
using static laziiMenu.Classes.ColorChangerRain;

namespace laziiMenu.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        // Constant
        public static void Prefix()
        {



            try
            {
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen").GetComponent<MeshRenderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = OrangeUI;
                GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/campgroundstructure/scoreboard/REMOVE board").GetComponent<Renderer>().material = OrangeUI;

                //GameObject.Find("Mountain/UI/Text/monitor").GetComponent<Renderer>().material = OrangeUI;
                //GameObject.Find("skyjungle/UI/-- Clouds PhysicalComputer UI --/monitor (1)").GetComponent<Renderer>().material = OrangeUI;
                //GameObject.Find("TreeRoom/TreeRoomInteractables/UI/-- PhysicalComputer UI --/monitor").GetComponent<Renderer>().material = OrangeUI;
                //GameObject.Find("Beach/BeachComputer/UI FOR BEACH COMPUTER/Text/monitor").GetComponent<Renderer>().material = OrangeUI;
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError(string.Format("Eclipse <b>COLOR ERROR</b> {1} - {0}", exception.Message, exception.StackTrace));
            }

            try
            {
                OrangeUI.color = UnityEngine.Color.black;

                GameObject motdText = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd");
                Text motdTC = motdText.GetComponent<Text>();
                RectTransform motdTRC = motdText.GetComponent<RectTransform>();
                motdTC.supportRichText = true;
                motdTC.fontSize = 24;
                motdTC.text = "Thanks for using Eclipse Mod Menu!";
                motdTC.color = textColor;
                motdTRC.sizeDelta = new Vector2(379.788f, 155.3812f);
                motdTRC.localScale = new Vector3(0.00395f, 0.00395f, 0.00395f);

                GameObject myfavorite = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext");
                Text motdTextB = myfavorite.GetComponent<Text>();
                RectTransform transformation = myfavorite.GetComponent<RectTransform>();
                transformation.localPosition = new Vector3(-184.4942f, -49.3492f, -0.0006f);
                motdTextB.supportRichText = true;
                motdTextB.fontSize = 60;
                motdTextB.font = activeFont;
                motdTextB.color = textColor;
                motdTextB.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                transformation.sizeDelta = new Vector2(583.6444f, 486.2244f);
                transformation.localScale = new Vector3(0.2281f, 0.2281f, 0.2281f);
                motdTextB.text = @"
You are using version 1.0b2. This menu was developed by lazii
(@lazii_dev) on discord. You are currently using the free menu,
the payed menu will be out.possibly next month. I, lazii, am not
responsible for any bans using this menu. If you get banned
while using this, please report it to the discord server.";
            }
            catch { }

            leftgrip = ControllerInputPoller.instance.leftGrab || UnityInput.Current.GetKey(KeyCode.LeftBracket);
            rightgrip = ControllerInputPoller.instance.rightGrab || UnityInput.Current.GetKey(KeyCode.RightBracket);
            leftTrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);
            rightTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand);
            shouldBePC = UnityInput.Current.GetKey(KeyCode.E) || UnityInput.Current.GetKey(KeyCode.R) || UnityInput.Current.GetKey(KeyCode.F) || UnityInput.Current.GetKey(KeyCode.G) || UnityInput.Current.GetKey(KeyCode.LeftBracket) || UnityInput.Current.GetKey(KeyCode.RightBracket) || UnityInput.Current.GetKey(KeyCode.Minus) || UnityInput.Current.GetKey(KeyCode.Equals) || Mouse.current.leftButton.isPressed || Mouse.current.rightButton.isPressed;
            // Initialize Menu
            try
            {
                bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if ((toOpen || keyboardOpen))
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        if (rightHanded)
                        {
                            comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }

                        UnityEngine.Object.Destroy(menu, 2);
                        menu = null;

                        UnityEngine.Object.Destroy(reference);
                        reference = null;
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }

            // Constant
            try
            {
                // Pre-Execution
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                }


                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
        }

        // Functions

        public static void ChangeColor(Color color)
        {
            if (PhotonNetwork.InRoom)
            {
                if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
                {
                    PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
                    PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
                    PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));

                    //GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = color;
                    GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
                    PlayerPrefs.Save();

                    GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.All, new object[] { color.r, color.g, color.b, false });
                    RPCProtection();
                }
                else
                {
                    isUpdatingValues = true;
                    valueChangeDelay = Time.time + 0.5f;
                    changingColor = true;
                    colorChange = color;
                }
            }
            else
            {
                PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
                PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
                PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));

                //GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = color;
                GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
                PlayerPrefs.Save();

                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.All, new object[] { color.r, color.g, color.b, false });
                RPCProtection();
            }
        }

        

        public static void ChangeName(string PlayerName)
        {
            try
            {
                if (PhotonNetwork.InRoom)
                {
                    if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
                    {
                        GorillaComputer.instance.currentName = PlayerName;
                        PhotonNetwork.LocalPlayer.NickName = PlayerName;
                        GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
                        GorillaComputer.instance.savedName = PlayerName;
                        PlayerPrefs.SetString("playerName", PlayerName);
                        PlayerPrefs.Save();

                        ChangeColor(GorillaTagger.Instance.offlineVRRig.playerColor);
                    }
                    else
                    {
                        isUpdatingValues = true;
                        valueChangeDelay = Time.time + 0.5f;
                        changingName = true;
                        nameChange = PlayerName;
                    }
                }
                else
                {
                    GorillaComputer.instance.currentName = PlayerName;
                    PhotonNetwork.LocalPlayer.NickName = PlayerName;
                    GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
                    GorillaComputer.instance.savedName = PlayerName;
                    PlayerPrefs.SetString("playerName", PlayerName);
                    PlayerPrefs.Save();

                    ChangeColor(GorillaTagger.Instance.offlineVRRig.playerColor);
                }
            }
            catch (Exception exception)
            {
                UnityEngine.Debug.LogError(string.Format("Eclipse <b>NAME ERROR</b> {1} - {0}", exception.Message, exception.StackTrace));
            }
        }



        public static void CreateMenu()
        {
            // Menu Holder
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
            menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = menuSize;
            menuBackground.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);

            ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();

            // Canvas
            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
            Text text = new GameObject
            {
                transform =
                    {
                        parent = canvasObject.transform
                    }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = PluginInfo.Name + " <color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>";
            text.fontSize = 1;
            text.color = textColors[0];
            text.supportRichText = true;
            text.fontStyle = FontStyle.Italic;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.05f);
            component.position = new Vector3(0.06f, 0f, 0.165f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            if (fpsCounter)
            {
                fpsObject = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                fpsObject.font = currentFont;
                fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                fpsObject.color = textColors[0];
                fpsObject.fontSize = 1;
                fpsObject.supportRichText = true;
                fpsObject.fontStyle = FontStyle.Italic;
                fpsObject.alignment = TextAnchor.MiddleCenter;
                fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                fpsObject.resizeTextForBestFit = true;
                fpsObject.resizeTextMinSize = 0;
                RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.28f, 0.02f);
                component2.position = new Vector3(0.06f, 0f, 0.135f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Buttons
            // Disconnect
            if (disconnectButton)
            {
                GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    disconnectbutton.layer = 2;
                }
                UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                disconnectbutton.transform.parent = menu.transform;
                disconnectbutton.transform.rotation = Quaternion.identity;
                disconnectbutton.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
                disconnectbutton.transform.localPosition = new Vector3(0.56f, 0f, 0.6f);
                disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";

                colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];
                colorChanger.Start();

                Text discontext = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                discontext.text = "Disconnect";
                discontext.font = currentFont;
                discontext.fontSize = 1;
                discontext.color = textColors[0];
                discontext.alignment = TextAnchor.MiddleCenter;
                discontext.resizeTextForBestFit = true;
                discontext.resizeTextMinSize = 0;

                RectTransform rectt = discontext.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                rectt.localPosition = new Vector3(0.064f, 0f, 0.23f);
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Page Buttons
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.9f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0.65f, 0);
            gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = buttonColors[0];
            colorChanger.Start();

            text = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = "<";
            text.fontSize = 1;
            text.color = textColors[0];
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.064f, 0.195f, 0f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.9f);
            gameObject.transform.localPosition = new Vector3(0.56f, -0.65f, 0);
            gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = buttonColors[0];
            colorChanger.Start();

            text = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = ">";
            text.fontSize = 1;
            text.color = textColors[0];
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.064f, -0.195f, 0f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.1f, activeButtons[i]);
            }
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = buttonColors[1];
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Italic;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }
                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                    GameObject.Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            }
            else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                }
                else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=grey>[</color><color=red>DISABLE</color><color=grey>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=grey>[</color><color=green>ENABLE</color><color=grey>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        

        // Variables
        // Important
        // Objects
        public static GameObject menu;
        public static GameObject menuBackground;
        public static GameObject reference;
        public static GameObject canvasObject;

        public static SphereCollider buttonCollider;
        public static Camera TPC;
        public static Text fpsObject;
        public static GameObject leftplatform = null;
        public static GameObject rightplatform = null;
        public static bool leftgrip = false;
        public static bool rightgrip = false;
        public static float leftTrigger = 0f;
        public static float rightTrigger = 0f;
        public static bool plastLeftGrip = false;
        public static bool plastRightGrip = false;
        public static bool shouldBePC = false;
        public static bool isUpdatingValues = false;
        public static float valueChangeDelay = 0f;
        public static bool changingName = false;
        public static bool changingColor = false;
        public static string nameChange = "";
        public static Color colorChange = Color.black;
        public static VRRig whoCopy = null;
        public static bool isCopying = false;
        public static Material OrangeUI = new Material(Shader.Find("GorillaTag/UberShader"));
        public static Color textColor = new Color32(255, 190, 125, 255);
        public static bool isJoiningRandom = false;
        public static float jrDebounce = 0f;
        public static float internetFloat = 3f;
        public static float h = ((Time.frameCount / 180f) + offset) % 1f;
        public static float offset;
        public static Font agency = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
        public static Font activeFont = agency;

        // Data
        public static int pageNumber = 0;
        public static int buttonsType = 0;
    }
}
