using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.XR;
using UnityEngine;

namespace laziiMenu.Mods
{
    internal class noClip
    {
        public static void NoClip()
        {
            if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) == 1f)
            {
                foreach (MeshCollider m in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    m.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider m2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    m2.enabled = true;
                }
            }
        }
    }
}

