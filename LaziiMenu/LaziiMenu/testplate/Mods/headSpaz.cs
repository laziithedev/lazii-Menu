using System;
using System.Collections.Generic;
using System.Text;

namespace EclipseMenu.Mods
{
    internal class headSpaz
    {
        public static void headspaz()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = UnityEngine.Random.Range(0f, 360f);
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = UnityEngine.Random.Range(0f, 360f);
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = UnityEngine.Random.Range(0f, 360f);
        }

        public static void FixHead()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 0f;
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 0f;
        }

    }
}
