using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static laziiMenu.Menu.Main;

namespace laziiMenu.Classes
{
    internal class ColorChangerRain
    {
        public static void ColorRainbow(float offset)
        {
            float h = ((Time.frameCount / 180f) + offset) % 1f;
            UnityEngine.Color.HSVToRGB(h, 1f, 1f);
        }
    }
}
