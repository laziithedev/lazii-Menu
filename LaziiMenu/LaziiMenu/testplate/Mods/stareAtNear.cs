using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using static EclipseMenu.Classes.RigManager;

namespace EclipseMenu.Mods
{
    internal class stareAtNear
    {
        public static void StareAtClosest()
        {
            GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(GetClosestVRRig().headMesh.transform.position);
        }
    }
}
