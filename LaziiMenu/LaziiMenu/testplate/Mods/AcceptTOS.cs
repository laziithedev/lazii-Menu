using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace EclipseMenu.Mods
{
    internal class AcceptTOS
    {
        public static void AcceptTOSM()
        {
            GameObject.Find("Miscellaneous Scripts/LegalAgreementCheck/Legal Agreements")
                .GetComponent<LegalAgreements>().testFaceButtonPress = true;
        }
    }
}
