using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace laziiMenu.Mods
{
    internal class FPSBoost
    {
        public static void FPSBoostOn()
        {
            QualitySettings.globalTextureMipmapLimit = 99999;
        }

        public static void FPSboostOff()
        {
            QualitySettings.globalTextureMipmapLimit = 1;
        }   

    }
}
