using UnityEngine;

namespace EclipseMenu.Classes
{
    public class ColorChanger : TimedBehaviour
    {
        public override void Start()
        {
            base.Start();
            renderer = GetComponent<Renderer>();
            Update();
        }

        public override void Update()
        {
            base.Update();
            if (colorInfo != null)
            {
                if (!colorInfo.copyRigColors)
                {
                    // Calculate the time for the gradient
                    float time = Time.time / 2f % 1;

                    // Get the color from the gradient
                    Color color = new Gradient { colorKeys = colorInfo.colors }.Evaluate(time);

                    // Set the color
                    renderer.material.color = color;
                }
                else
                {
                    renderer.material = GorillaTagger.Instance.offlineVRRig.mainSkin.material;
                }
            }
        }

        public Renderer renderer;
        public ExtGradient colorInfo;
    }
}
