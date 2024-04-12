using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using static laziiMenu.Classes.RigManager;

namespace laziiMenu.Mods
{
    internal class stareAtNear
    {
        public static void StareAtClosest()
        {
            GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(GetClosestVRRig().headMesh.transform.position);
        }
    }
}
