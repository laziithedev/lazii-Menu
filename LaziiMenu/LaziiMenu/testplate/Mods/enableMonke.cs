using System;
using System.Collections.Generic;
using System.Text;

namespace EclipseMenu.Mods
{
    internal class enableMonke
    {
        public static void EnableMonke()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }
    }
}
