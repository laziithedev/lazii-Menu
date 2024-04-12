using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static EclipseMenu.Menu.Main;

namespace EclipseMenu.Classes
{
    internal class ColorChangerRain
    {
        public static void ColorRainbow(float offset)
        {
            float h = (Time.frameCount / 180f + offset) % 1f;
            Color.HSVToRGB(h, 1f, 1f);
        }
    }
}
