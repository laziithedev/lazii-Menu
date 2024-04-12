using System;
using UnityEngine;

namespace EclipseMenu.Classes
{
    public class ExtGradient
    {
        public GradientColorKey[] colors = new GradientColorKey[]
        {

            new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0f), // Dark purple at the start
            new GradientColorKey(Color.black, 0.5f), // Black in the middle
            new GradientColorKey(new Color(0.5f, 0f, 0.5f), 1f) // Dark purple at the end

    };

        public bool isRainbow = false;
        public bool copyRigColors = false;
    }
}
